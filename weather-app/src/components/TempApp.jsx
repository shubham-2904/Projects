import { useContext, useEffect } from "react";
import WeatherAppContextProvider from "../store/weather-app-store";
import DisplayInfo from "./DisplayInfo";
import WeatherInfo from "./WeatherInfo";

const TempApp = () => {

  return (
    <>
      <WeatherAppContextProvider>
        <div className="container">
          <DisplayInfo />
          <WeatherInfo />
        </div>
      </WeatherAppContextProvider>
    </>
  )
};

export default TempApp;