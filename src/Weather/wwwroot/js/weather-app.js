'use strict';

var WeatherApp = WeatherApp || {};

WeatherApp.Main = function () {
    var _service = Object.create(WeatherApp.forecastService),
        viewRenderer = Object.create(WeatherApp.ViewUpdater);

    viewRenderer.constructor();

    _service.getForecast(viewRenderer.update);
};

WeatherApp.Main();
