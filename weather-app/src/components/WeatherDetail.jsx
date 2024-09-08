import { useState, useEffect } from "react"

const WeatherDetail = ({ cityDetial, loading, weatherDetail }) => {
  const [cityName, setCityName] = useState('');
  const [country, setCountry] = useState('');
  const [weatehrInfo, setWeatherInfo] = useState('');

  // conditional calling it re-render the component when the state of loading change
  useEffect(() => {
    if (!loading) {
      setCityName(cityDetial.name);
      setCountry(cityDetial.country);
      setWeatherInfo(weatherDetail)
    }
  }, [loading]);

  return (
    <div className="weatherDetails">
      <div className="cityName">
        {cityName}, {country}
      </div>
      <hr />
      <div className="cityWeatherDetail">
        <div className="keyValue">
          <p className="key">Humidity</p>
          <p className="value">{weatehrInfo.humidity} %</p>
        </div>
        <hr />
        <div className="keyValue">
          <p className="key">Visibility</p>
          <p className="value">{weatehrInfo.visibility} Km</p>
        </div>
        <hr />
        <div className="keyValue">
          <p className="key">Wind Speed</p>
          <p className="value">{weatehrInfo.windSpeed} Km/Hr</p>
        </div>
        <hr />
      </div>
    </div>
  )
}

export default WeatherDetail
