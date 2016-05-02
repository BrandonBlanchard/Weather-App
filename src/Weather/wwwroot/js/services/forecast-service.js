'use strict';

var WeatherApp = WeatherApp || {};

WeatherApp.forecastService = {

    baseUrl: 'api/getforecastforthisweek/',

    getHighLowForWeek: function () {

    },

    getForecast: function(cb){
        var ajaxArgs = {
            url: this.baseUrl + '37.8267,-122.423' // seattle
        },

        doneCB = function (data) {
            console.log(cb);
            cb(data);
        };

        $.ajax(ajaxArgs)
            .done(doneCB);
    }
};