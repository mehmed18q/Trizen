using AutoMapper;
using Trizen.Application.Interfaces;
using Trizen.Data.Travel.Dto;
using Trizen.Data.Travel.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Services;

internal class TravelService(ITravelRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, ITourRepository tourRepository) : ITravelService, IRegisterServices
{
    private readonly ITravelRepository _repository = repository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITourRepository _tourRepository = tourRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<BasketViewModel>> Create(CreateTravelDto dto)
    {
        Travel? onProcessTravel = await _repository.GetOnProcessTravel(dto.UserId, dto.TourId);
        if (onProcessTravel is not null)
        {
            Response<BasketViewModel> travel = await Get(onProcessTravel.Id);

            return Response<BasketViewModel>.SuccessResult(travel.Data);
        }

        if (await _tourRepository.AnyWithCapacity(dto.TourId, 1) || await _tourRepository.Any(dto.TourId))
        {
            Travel _travel = _mapper.Map<Travel>(dto);
            _travel.Passengers.Add(new Passenger
            {
                PassengerUserId = dto.UserId,
            });

            _ = await _repository.Insert(_travel);
            await _unitOfWork.SaveChangesAsync();
            Response<BasketViewModel> travel = await Get(_travel.Id);

            return Response<BasketViewModel>.SuccessResult(travel.Data);
        }
        return Response<BasketViewModel>.FailResult(null, Message.TheTourHaveNotCapacity);
    }

    public async Task<Response<BasketViewModel>> Get(int travelId)
    {
        Travel? _travel = await _repository.Get(travelId);
        BasketViewModel travel = _mapper.Map<BasketViewModel>(_travel);

        return Response<BasketViewModel>.SuccessResult(travel);
    }

    public async Task<Response<double>> TravelPassengerInsertUpdate(PassengerTravelDto dto)
    {
        if (await _repository.Any(dto.TravelId))
        {
            Travel? travel = await _repository.Get(dto.TravelId);
            IEnumerable<int> _travelPassengers = dto.TravelPassengers?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int passengerUserId in _travelPassengers)
            {
                if (await _userRepository.AnyUser(passengerUserId) && !travel!.Passengers.Any(passenger => passenger.PassengerUserId == passengerUserId))
                {
                    travel.Passengers.Add(new Passenger
                    {
                        PassengerUserId = passengerUserId,
                        TravelId = travel.Id,
                    });
                }
            }

            List<Passenger> deletes = travel!.Passengers
    .Where(passenger => !_travelPassengers.Contains(passenger.PassengerUserId))
    .ToList();

            foreach (Passenger item in deletes)
            {
                _ = travel.Passengers.Remove(item);
            }

            await _repository.Update(travel);
            await _unitOfWork.SaveChangesAsync();
            return Response<double>.SuccessResult(travel.Passengers.Count * travel.Tour.Price);
        }

        return Response<double>.SuccessResult(0, Message.Format(Message.EntityNotFound, Resource.Tour));
    }

    public async Task<ListResponse<BasketViewModel>> GetUserBasket(int userId)
    {
        List<Travel> _travels = await _repository.GetUserBasket(userId);
        List<BasketViewModel> travels = _mapper.Map<List<BasketViewModel>>(_travels);

        return ListResponse<BasketViewModel>.SuccessResult(travels);
    }

    public async Task<Response<bool>> Pay(int travelId)
    {
        Travel? travel = await _repository.Get(travelId);
        if (travel is not null)
        {
            travel.Status = TravelStatus.Paid;
            await _repository.Update(travel);
            double priceOfTravel = travel.Tour.Price * travel.Passengers.Count;
            priceOfTravel += priceOfTravel / 10; // tax
            priceOfTravel *= -1; // Draw from Wallet
            await _userRepository.ChangeWallet(travel.UserId, priceOfTravel);
            await _unitOfWork.SaveChangesAsync();
        }

        return Response<bool>.SuccessResult(travel is not null);
    }

    public async Task<Response<bool>> Cancel(int travelId)
    {
        Travel? travel = await _repository.Get(travelId);
        if (travel is not null)
        {
            if (travel.Status == TravelStatus.Paid)
            {
                double priceOfTravel = travel.Tour.Price * travel.Passengers.Count;
                await _userRepository.ChangeWallet(travel.UserId, priceOfTravel);
            }
            travel.Status = TravelStatus.Cancelled;
            await _repository.Update(travel);
            await _unitOfWork.SaveChangesAsync();
        }

        return Response<bool>.SuccessResult(travel is not null);
    }
}