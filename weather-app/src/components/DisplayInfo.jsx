import { useContext, useEffect, useState, useRef } from "react";
import DateView from "./DateView";
import TimeView from "./TimeView";
import { WeatherAppContext } from "../store/weather-app-store";

const DisplayInfo = () => {
  const [temp, setTemp] = useState(null);
  const context = useContext(WeatherAppContext);
  const weatherImageRef = useRef(null);

  function setWeatherBackgroundImage(weatherInfo) {
    switch (weatherInfo.id) {
      case 200:
      case 201:
      case 202:
      case 210:
      case 211:
      case 212:
      case 221:
      case 230:
      case 231:
      case 232:
        weatherImageRef.current.style.backgroundImage = 'url(Images/thunderstorm_weather.jpg)';
        break;
      case 300:
      case 301:
      case 302:
      case 310:
      case 311:
      case 312:
      case 313:
      case 314:
      case 321:
        weatherImageRef.current.style.backgroundImage = 'url(Images/rainy_weather.jpg)';
        break;
      case 500:
      case 501:
      case 502:
      case 503:
      case 504:
        weatherImageRef.current.style.backgroundImage = 'url(Images/rainy_weather.jpg)';
        break;
      case 511:
        weatherImageRef.current.style.backgroundImage = 'url(Images/snow_weather.jpg)';
        break;
      case 520:
      case 521:
      case 522:
      case 531:
        weatherImageRef.current.style.backgroundImage = 'url(Images/rainy_weather.jpg)';
        break;
      case 600:
      case 601:
      case 602:
      case 611:
      case 612:
      case 613:
      case 615:
      case 616:
      case 620:
      case 621:
      case 622:
        weatherImageRef.current.style.backgroundImage = 'url(Images/mistsnow_weather_weather.jpg)';
        break;
      case 701:
      case 711:
      case 721:
      case 731:
      case 741:
      case 751:
      case 761:
      case 762:
      case 771:
      case 781:
        weatherImageRef.current.style.backgroundImage = 'url(Images/mist_weather.jpg)';
        break;
      case 800:
        weatherImageRef.current.style.backgroundImage = 'url(Images/clear_weather.jpg)';
        break;
      case 801:
        weatherImageRef.current.style.backgroundImage = 'url(Images/clear_weather.jpg)';
        break;
      case 802:
        weatherImageRef.current.style.backgroundImage = 'url(Images/clear_weather.jpg)';
        break;
      case 803:
      case 804:
        weatherImageRef.current.style.backgroundImage = 'url(Images/clear_weather.jpg)';   
        break;
      default:
        weatherImageRef.current.style.backgroundImage = 'url(Images/clear_weather.jpg)';
        break;
    }
  }

  useEffect(() => {    
    if (context.wetherDetail != null) {
      setTemp(context.wetherDetail.temp)
      setWeatherBackgroundImage(context.wetherDetail.weather[0])
    }
  }, [context.isLoading]);

  return (
    <>
      <div className="weatherImg"
        ref={weatherImageRef}
      >
        <div className="overlay"></div>
        <div className="Info">
          <div className="dateTime">
            <DateView />
            <TimeView />
          </div>
          <div className="temperatureInfo">
            {temp}&deg;C
          </div>
        </div>
      </div>
    </>
  )
}

export default DisplayInfo
