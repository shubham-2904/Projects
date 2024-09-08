import { useContext, useEffect, useState } from "react";
import { MdOutlineWbSunny } from "react-icons/md";
import { WeatherAppContext } from "../store/weather-app-store";
import { RiMistFill } from "react-icons/ri";
import { BsCloudDrizzle, BsFillCloudLightningRainFill, BsClouds } from "react-icons/bs";
import { TbSnowflake } from "react-icons/tb";
import { IoRainy } from "react-icons/io5";
import { GiRaining } from "react-icons/gi";
import { CiCloudSun, CiCloudOn } from "react-icons/ci";


const WeatherSummary = () => {
  const [weatherName, setWeatherName] = useState(null);
  const [icon, setIcon] = useState(null);
  const {wetherDetail, isLoading} = useContext(WeatherAppContext);
  let weather = null;

  useEffect( () => {
    if(!isLoading) {
      weather = wetherDetail.weather[0];
      setWeatherName(weather.main);
      setIcon(weather.id);
    }
  }
  ,[isLoading])
   
  return (
    <div className="weatherSummary">
      <div className="weatherIcon">
        <WeatherIcon weatherIcon={icon} />
      </div>
      <div className="weatherName">
        {weatherName}
      </div>
    </div>
  )
}

const WeatherIcon = ({ weatherIcon }) => {
  switch (weatherIcon) {
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
      return (
        <BsFillCloudLightningRainFill />
      );
    case 300:
    case 301:
    case 302:
    case 310:
    case 311:
    case 312:
    case 313:
    case 314:
    case 321:
      return(
        <BsCloudDrizzle />
      );
    case 500:
    case 501:
    case 502:
    case 503:
    case 504:
      return (
        <IoRainy />
      );
    case 511:
      return (
        <TbSnowflake />
      );
    case 520:
    case 521:
    case 522:
    case 531:
      return (
        <GiRaining />
      );
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
      return (
        <TbSnowflake />
      );
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
      return (
        <RiMistFill />
      );
    case 800:
      return (
        <MdOutlineWbSunny />
      );
    case 801:
    return (
      <CiCloudSun />
    );
    case 802:
    return (
      <CiCloudOn />
    );
    case 803:
    case 804:
    return (
      <BsClouds />
    );     
    default:
      return (
        <MdOutlineWbSunny />
      );
  }
}

export default WeatherSummary
