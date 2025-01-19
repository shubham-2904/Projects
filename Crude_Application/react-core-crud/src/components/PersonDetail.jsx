import { useContext } from "react"
import { PersonContext } from "../store/person-store";

// Function to print the list of person to the table
const PersonDetail = ({ sendPersonDataToParent }) => {
    // Consuming the context hook
    const personContext = useContext(PersonContext);
    const personList = personContext.personList;

    const handleTableRowData = (event, person) => {
        if (event.isTrusted) {
            sendPersonDataToParent(person)
        }
    }

    return (
        <div className='pl-1 mt-10 w-8/12 overflow-y-auto max-h-[450px]'>
            <table className="border-collapse w-full border border-slate-500">
                <thead className="bg-slate-700 sticky top-0 z-10">
                    <tr>
                        <th className="border border-slate-600 w-4/12 text-white text-left font-semibold p-4">
                            First Name
                        </th>
                        <th className="border border-slate-600 w-4/12 text-white text-left font-semibold p-4">
                            Last Name
                        </th>
                        <th className="border border-slate-600 w-4/12 text-white text-left font-semibold p-4">
                            Age
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {
                        personList != null && personList.length > 0 ?
                            personList.map((person, index) => (
                                // If odd
                                (index + 1) % 2 != 0 ?
                                    <tr key={person.id}
                                        onClick={() => handleTableRowData(event, person)}
                                        className="bg-slate-200 hover:bg-slate-400 duration-300 w-full">
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.first_Name}
                                        </td>
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.last_Name}
                                        </td>
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.age}
                                        </td>
                                    </tr>
                                    :
                                    // if even
                                    <tr key={person.id}
                                        onClick={() => handleTableRowData(event, person)}
                                        className="hover:bg-slate-400 duration-300 w-full">
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.first_Name}
                                        </td>
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.last_Name}
                                        </td>
                                        <td className="border border-slate-600 p-4 bg-">
                                            {person.age}
                                        </td>
                                    </tr>
                            ))
                            :
                            <tr>
                                <td colSpan="3" className="text-center">
                                    No Data Found
                                </td>
                            </tr>

                    }
                </tbody>
            </table>
        </div>
    )
}

export default PersonDetail