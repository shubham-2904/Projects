import { useEffect, useState } from "react"

const DateView = () => {
  const [weekDay, setWeekDay] = useState("")

  useEffect(() => {
    const getWeekdayName = (date) => {
      const dayOfWeek = date.getDay();
      const weekdays = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
      return weekdays[dayOfWeek];
    };

    const now = new Date();
    setWeekDay(getWeekdayName(now));
  }, []);

  return (
    <>
      <h1>{weekDay}</h1>
    </>
  )
}

export default DateView;
