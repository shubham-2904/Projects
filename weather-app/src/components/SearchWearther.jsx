import { useContext, useRef } from "react";
import { FaSearch } from "react-icons/fa";
import { WeatherAppContext } from "../store/weather-app-store";

const SearchWearther = () => {
  const city = useRef();
  const context = useContext(WeatherAppContext)

  const handleSearch = () => {
    //context.getCityLocation(city.current.value);
    context.getCityWeather(city.current.value);
    city.current.value = '';
  }

  return (
    <div className="weatherSearch">
      <input type="text" ref={city} />
      <span className="searchButton"
        onClick={handleSearch}
      >
        <FaSearch />
      </span>
    </div>
  )
}

export default SearchWearther
