'use strict';

var WeatherApp = WeatherApp || {};

WeatherApp.ViewUpdater = {
    days: [],

    constructor: function () {

        for (var i = 0; i < 7; i += 1) {
            var day = Object.create(WeatherApp.Day);
            day.constructor(i);

            this.days.push(day);

            // Ensure our callback does not lose scope
            this.update = this.update.bind(this);
        } 
    },

    update: function (data) {
        
        if (!data || !data.Forecast || data.Forecast.length < 1) {
            return;
        }

        for (var i = 0; i < this.days.length; i += 1) {
            var todaysData = data.Forecast[i];
            this.days[i].update(todaysData.Day, todaysData.Low, todaysData.High, todaysData.Climacon);
        }
    }
};