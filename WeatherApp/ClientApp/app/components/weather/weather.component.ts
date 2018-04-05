import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ERROR_LOGGER } from '@angular/core/src/errors';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Component({
    selector: 'weather',
    template: require('./weather.component.html')
})
export class WeatherComponent {
    public weather: Weather;
    public error: ErrorObservable;

    constructor(private http: Http) { }

    public getCurrentWeather(zipcode: string) {
        this.http.get('/api/weather/' + zipcode).subscribe(
            data => {
                this.error = new ErrorObservable('');
                this.weather = data.json();
            },
            error => {
                console.error('Could not retrieve weather data. Error code: ' + error.status + ' Message: ' + error.statusText);
                this.error = new ErrorObservable('Unable to retrieve weather information');
            });
    }
}

interface Weather {
    currentTemperature: string;
    highTemperature: string;
    lowTemperature: string;
    weather: string;
    windSpeed: string;
    station: string;
}