try {
    jalaliDatepicker.startWatch();
} catch (e) {}

ToastActions = {
    Success: "success",
    Warning: "warning",
    Info: "info",
    Error: "error",
    Alert: "alert",
    Reload: "reload"
};

async function PostAsync(url, Indata, inindataType = "json") {
    var outData;
    //console.log('eeee');
    $.ajax({
        type: "POST",
        url: url,
        dataType: inindataType,
        async: false,
        data: Indata,
        success: function (data) {
            outData = data;
        },
        error: function (data) {
            toast('خطا', `!خطای ${data.status} رخ داده است`, ToastActions.Error);
            outData = data;
        }
    });

    return Promise.resolve(outData);
}

function toast(title, text, icon, time = 4000) {
    loaderBgColer = "#71b371";
    _bgColer = "#3C763D";
    if (icon == ToastActions.Error) {
        loaderBgColer = "#ca5e58";
        _bgColer = "#A94442";
    }
    else if (icon == ToastActions.Info) {
        loaderBgColer = "#56a9c1";
        _bgColer = "#31708F";
    }
    else if (icon == ToastActions.Warning) {
        loaderBgColer = "#f7a735";
        _bgColer = "#d1881f";
    }

    $.toast({
        heading: title, // Title of Alert
        text: text,
        showHideTransition: 'plain',  // It can be plain, fade or slide
        bgColor: _bgColer,              // Background color for toast
        textColor: '#eee',            // text color
        allowToastClose: true,       // Show the close button or not
        hideAfter: time,              // `false` to make it sticky or time in miliseconds to hide after
        stack: 6,                     // `fakse` to show one stack at a time count showing the number of toasts that can be shown at once
        textAlign: 'right',            // Alignment of text i.e. left, right, center
        position: 'bottom-right',
        icon: icon,
        extendedTimeOut: time,
        loader: true,        // Change it to false to disable loader
        loaderBg: loaderBgColer  // To change the background// bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values to position the toast on page
    })
}

async function LikeTour(tourId) {
    if (tourId != undefined && tourId != null && tourId != 0) {
        var data = await PostAsync("/Account/LikeTour", { tourId: tourId });
        if (data.isSuccess) {
            toast('افزودن به علاقه مندی ها', data.message ?? data.data, ToastActions.Success);
            return;
        }
    }

    toast('خطا', `!خطای ${data.status} رخ داده است`, ToastActions.Error);
}

async function LikeDestination(destinationId) {
    if (destinationId != undefined && destinationId != null && destinationId != 0) {
        var data = await PostAsync("/Account/LikeDestination", { destinationId: destinationId });
        if (data.isSuccess) {
            toast('افزودن به علاقه مندی ها', data.message ?? data.data, ToastActions.Success);
            return;
        }
    }

    toast('خطا', `!خطای ${data.status} رخ داده است`, ToastActions.Error);
}



async function TravelPassengers(travelId, travelPassengers) {
    if (travelId != undefined && travelId != null && travelId != 0) {
        var data = await PostAsync("/Travels/TravelPassengers", { TravelId: travelId, TravelPassengers: travelPassengers });
    }
}