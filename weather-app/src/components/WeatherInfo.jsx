import { useContext, useEffect, useState } from "react";
import SearchWearther from "./SearchWearther";
import WeatherDetail from "./WeatherDetail";
import WeatherSummary from "./WeatherSummary";
import { WeatherAppContext } from "../store/weather-app-store";

const WeatherInfo = () => {
  const context = useContext(WeatherAppContext)

  return (
    <>
      <div className="weatherInfo">
        <WeatherSummary />
        <hr />
        <SearchWearther />
        <WeatherDetail
          cityDetial={context.data}
          loading={context.isLoading}
          weatherDetail={context.wetherDetail} />
      </div>
    </>
  )
}

export default WeatherInfo
