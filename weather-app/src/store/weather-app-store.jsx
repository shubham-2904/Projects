import { createContext, useEffect, useState } from "react";

export const WeatherAppContext = createContext({
  wetherDetail: null,
  isLoading: null,
  data: null,
  getCityLocation: () => { },
});

// Base Urls for weather and geolocation
const weatherURL = 'https://api.openweathermap.org/data/2.5/weather?';
const geolocation = 'http://api.openweathermap.org/geo/1.0/direct?';
const apiKey = '{API_KEY}'
const DEFAULT_CITY = 'Delhi';

const WeatherAppContextProvider = (props) => {
  const [data, setData] = useState(null);
  const [weatherInfo, setWeatherInfo] = useState(null);
  const [loading, setLoading] = useState(true);

  // this will run only one time when the component `WeatherAppContextProvider` is mounted
  useEffect(() => {
    getLongitudeLatitude(DEFAULT_CITY);
  }, []);

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
          //console.log(result[0]);
          setData(result[0]);
          getWeatherDetail(result[0].lon, result[0].lat);
        }
      })
      .catch(error => console.log('Error fetching city data:', error));
  }

  return (
    <WeatherAppContext.Provider value={{
      wetherDetail: weatherInfo,
      isLoading: loading,
      data: data,
      getCityLocation: getLongitudeLatitude
    }}>
      {props.children}
    </WeatherAppContext.Provider>
  );
};

export default WeatherAppContextProvider;