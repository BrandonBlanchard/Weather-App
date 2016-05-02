'use strict';

var WeatherApp = WeatherApp || {};

// viewModel for individual days
WeatherApp.Day = {
    $id: '',
    $dayField: null,
    $tempMaxField: null,
    $tempMinField: null,
    $iconField: null,

    constructor: function (dayNumber) {
        this.$id = '#day-' + dayNumber;

        // Grab fields from dom for this day
        this.$dayField = $(this.$id + ' .tile-day');
        this.$tempMaxField = $(this.$id + ' .tile-temp--max');
        this.$tempMinField = $(this.$id + ' .tile-temp--min');
        this.$iconField = $(this.$id + ' .tile-icon');
    },

    update: function (dayName, minTemp, maxTemp, icon) {
        this.updateIcon(icon);
        this.$dayField.text(dayName);

        this.$tempMaxField.text(this.formatTemp(maxTemp));
        this.$tempMinField.text(this.formatTemp(minTemp));
    },

    updateIcon: function (newClasses) {
        // Remove existing climacon classes
        this.$iconField.removeClass('sun rain snow sleet wind cloud');
        // Add new climacon classes
        this.$iconField.addClass(newClasses);
    },

    formatTemp: function (temp) {
        var degrees = '°';

        return temp + degrees;
    }
};