import { useEffect, useState } from "react"

const TimeView = () => {
  const options = { day: '2-digit', month: 'long', year: 'numeric' }; // This options help to display the date like `16 July 2024`
  const [time, setTime] = useState(new Date())

  useEffect(() => {
    const intervalId = setInterval(() => {
      setTime(new Date());
    }, 1000);

    // clean up the time interval
    return () => {
      clearInterval(intervalId);
      console.log("canceling the interval");
    }
  }, []);

  return (
    <div>
      <h3>{time.toLocaleTimeString()}, {time.toLocaleDateString('en-GB', options)}</h3>
    </div>
  )
}

export default TimeView
