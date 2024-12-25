import { createContext, useEffect, useState } from "react";

export const WeatherAppContext = createContext({
  wetherDetail: null,
  isLoading: null,
  data: null,
  // getCityLocation: () => { },
  getCityWeather: () => { }
});

// Base Urls for weather and geolocation
const weatherURL = 'https://api.openweathermap.org/data/2.5/weather?';
const geolocation = 'http://api.openweathermap.org/geo/1.0/direct?';
const wetherURLByCityDetail = 'https://api.openweathermap.org/data/2.5/weather?'
const apiKey = '{API_KEY}'
const DEFAULT_CITY = 'Delhi';

const WeatherAppContextProvider = (props) => {
  const [data, setData] = useState(null);
  const [weatherInfo, setWeatherInfo] = useState(null);
  const [loading, setLoading] = useState(true);

  // this will run only one time when the component `WeatherAppContextProvider` is mounted
  useEffect(() => {
    // getLongitudeLatitude(DEFAULT_CITY);
    getCityWeather(DEFAULT_CITY);
  }, []);

  // Function to used to get the weather detail of city using thier geo coordination
  const getWeatherDetail = (longitude, latitude) => {
    let detail = null;

    var requestOptions = {
      method: 'GET',
      redirect: 'follow'
    };

    fetch(`${weatherURL}lat=${latitude}&lon=${longitude}&appid=${apiKey}&units=metric`, requestOptions)
      .then(response => response.json())
      .then(result => {
        if (result) {
          // making object for weather detail
          detail = {
            temp: result.main.temp,
            visibility: (result.visibility / 1000).toFixed(2),
            humidity: result.main.humidity,
            windSpeed: (result.wind.speed * 3.6).toFixed(2),
            weather: result.weather
          };
          setWeatherInfo(detail);
        }
        setLoading(false);
      })
      .catch(error => console.log('Error fetching city weather data:', error))

  }

  // Function to used to get the geo location of city by city name
  const getLongitudeLatitude = (cityName) => {
    var requestOptions = {
      method: 'GET',
      redirect: 'follow'
    };

    setLoading(true);

    fetch(`${geolocation}q=${cityName}&limit=1&appid=${apiKey}`, requestOptions)
      .then(response => response.json())
      .then(result => {
        if (result.length > 0) {
          setData(result[0]);
          getWeatherDetail(result[0].lon, result[0].lat);
        }
      })
      .catch(error => console.log('Error fetching city data:', error));
  }

  // Function used to get the weather details by `cityDetail` = {city name}, {state code}, {country code}
  const getCityWeather = (cityDetail) => {
    let detail = null;

    var requestOptions = {
      method: 'GET',
      redirect: 'follow'
    };

    // Indicator says that the data is being loading
    setLoading(true);

    fetch(`${wetherURLByCityDetail}q=${cityDetail}&appid=${apiKey}&units=metric`, requestOptions)
      .then(response => response.json())
      .then(result => {
        if (result) {
          // Making object of city detail like city name, and country
          let cityDetail = {
            name: result.name,
            country: result.sys.country
          }

          setData(cityDetail);

          // making object for weather detail
          detail = {
            temp: result.main.temp,
            visibility: (result.visibility / 1000).toFixed(2),
            humidity: result.main.humidity,
            windSpeed: (result.wind.speed * 3.6).toFixed(2),
            weather: result.weather
          };
          
          setWeatherInfo(detail);
        }

        // Indicator says that the data loading complete
        setLoading(false);
      })
      .catch(error => console.log('Error fetching city weather data:', error))
  }

  return (
    <WeatherAppContext.Provider value={{
      wetherDetail: weatherInfo,
      isLoading: loading,
      data: data,
      // getCityLocation: getLongitudeLatitude,
      getCityWeather: getCityWeather
    }}>
      {props.children}
    </WeatherAppContext.Provider>
  );
};

export default WeatherAppContextProvider;