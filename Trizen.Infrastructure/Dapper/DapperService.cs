using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Trizen.Infrastructure.Dapper;

public class DapperService<TParam, TRes>(IConfiguration configuration) : IDapperService<TParam, TRes> where TParam : class where TRes : class
{
    private readonly string _connectionString = configuration.GetConnectionString("TrizenConnection") ?? throw new InvalidOperationException("Connection String 'TrizenConnection' Not Found.");

    public async Task<bool> Procedure(string procedure, TParam parameters)
    {
        int x = -1;
        using SqlConnection connection = new(_connectionString);
        await connection.OpenAsync();
        int result = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
        return x >= 1;
    }

    public async Task<IEnumerable<TRestM>> Query<TRestM>(string query, TParam parameters)
    {
        using SqlConnection connection = new(_connectionString);
        await connection.OpenAsync();
        IEnumerable<TRestM> result = await connection.QueryAsync<TRestM>(query, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<TRestM?> FirstResultQuery<TRestM>(string command, TParam parameters)
    {
        return (await Query<TRestM>(command, parameters)).FirstOrDefault();
    }

    public async Task<(IEnumerable<T1>, IEnumerable<T2>)> MultiQuery<T1, T2>(string query, TParam parameters)
    {
        SqlConnection connection = new(_connectionString);

        await connection.OpenAsync();
        SqlMapper.GridReader result = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure);
        IEnumerable<T1> vt1 = result.Read<T1>();
        IEnumerable<T2> vt2 = result.Read<T2>();

        return (vt1, vt2);
    }

    public async Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> MultiQuery<T1, T2, T3>(string query, TParam parameters)
    {
        SqlConnection connection = new(_connectionString);

        await connection.OpenAsync();
        SqlMapper.GridReader result = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure);
        IEnumerable<T1> vt1 = result.Read<T1>();
        IEnumerable<T2> vt2 = result.Read<T2>();
        IEnumerable<T3> vt3 = result.Read<T3>();

        return (vt1, vt2, vt3);
    }

    public async Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>)> MultiQuery<T1, T2, T3, T4>(string query, TParam parameters)
    {
        SqlConnection connection = new(_connectionString);

        await connection.OpenAsync();
        SqlMapper.GridReader result = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure);
        IEnumerable<T1> vt1 = result.Read<T1>();
        IEnumerable<T2> vt2 = result.Read<T2>();
        IEnumerable<T3> vt3 = result.Read<T3>();
        IEnumerable<T4> vt4 = result.Read<T4>();

        return (vt1, vt2, vt3, vt4);
    }

    public async Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>)> MultiQuery<T1, T2, T3, T4, T5, T6, T7>(string query, TParam parameters)
    {
        SqlConnection connection = new(_connectionString);

        await connection.OpenAsync();
        SqlMapper.GridReader result = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure);
        IEnumerable<T1> vt1 = result.Read<T1>();
        IEnumerable<T2> vt2 = result.Read<T2>();
        IEnumerable<T3> vt3 = result.Read<T3>();
        IEnumerable<T4> vt4 = result.Read<T4>();
        IEnumerable<T5> vt5 = result.Read<T5>();
        IEnumerable<T6> vt6 = result.Read<T6>();
        IEnumerable<T7> vt7 = result.Read<T7>();

        return (vt1, vt2, vt3, vt4, vt5, vt6, vt7);
    }
}