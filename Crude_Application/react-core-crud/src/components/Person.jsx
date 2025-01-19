import { useContext, useEffect, useRef, useState } from "react"
import { PersonContext } from "../store/person-store";

const Person = ({ person, reRender, edit }) => {
    // defining the useRef hook for form
    const firstName = useRef(null);
    const lastName = useRef(null);
    const age = useRef(null);
    const personContext = useContext(PersonContext);
    const [isEdit, setIsEdit] = useState(false)
    const [personId, setPersonId] = useState(null)

    // This hook will help to fill the form field to edit person info
    useEffect(() => {
        if (person != null) {
            // setting person id
            setPersonId(person.id)
            firstName.current.value = person.first_Name;
            lastName.current.value = person.last_Name;
            age.current.value = person.age;

            setIsEdit(edit)
        }
    }, [person, reRender]);

    // Function to sumbit form (New and update person data)
    const handleSumbitForm = (event) => {
        event.preventDefault()

        let personInformation = {
            first_Name: firstName.current.value,
            last_Name: lastName.current.value,
            age: age.current.value
        }

        // validation
        let isError = formValidation(personInformation)
        if (isError) {
            return
        }

        if (!isEdit) {
            personContext.savePerson(personInformation)
        }
        else {
            personContext.updatePerson(personId, personInformation)
        }

        handleFormReset()
    }

    // Functio to delete person
    const handlePersonDelete = () => {
        personContext.deletePersonById(personId)
        handleFormReset()
    }

    // Function to reset for fields
    const handleFormReset = () => {
        setPersonId(null)
        firstName.current.value = null;
        lastName.current.value = null;
        age.current.value = null;

        setIsEdit(false)
    }

    // Function to Valide form
    const formValidation = (dataToValidate) => {
        // Field Validation
        if (dataToValidate.first_Name == "") {
            alert('Please enter the first name')
            return true;
        }
        if (dataToValidate.last_Name == "") {
            alert('Please enter the last name')
            return true;
        }
        if (dataToValidate.age == "") {
            alert('Please enter the age')
            return true;
        }
        // Validation for age
        let age = dataToValidate.age
        if (!Number(age)) {
            alert('Please entery age as number')
            return true;
        }
        if (Number(age) <= 0) {
            alert('Age can not be negative and zero')
            return true;
        }

        return false;
    }

    return (
        <div className='w-4/12 m-h-full p-4'>
            <h3 className='font-bold'>Person Information</h3>
            <form className='border border-black rounded p-4' onSubmit={handleSumbitForm}>
                <div>
                    {/* First Name */}
                    <div className="sm:col-span-4">
                        <label htmlFor="firstName" className="block text-sm/6 font-medium text-gray-900">
                            First Name
                        </label>
                        <div className="mt-2">
                            <div className="flex items-center rounded-md bg-white pl-3 outline outline-1 -outline-offset-1 outline-gray-300 focus-within:outline focus-within:outline-2 focus-within:-outline-offset-2 focus-within:outline-slate-600">
                                <input
                                    id="firstName"
                                    name="firstName"
                                    type="text"
                                    ref={firstName}
                                    placeholder="Enter you first name"
                                    className="block min-w-0 grow py-1.5 pl-1 pr-3 text-base text-gray-900 placeholder:text-gray-400 focus:outline focus:outline-0 sm:text-sm/6"
                                />
                            </div>
                        </div>
                    </div>
                    {/* Last Name */}
                    <div className="sm:col-span-4 mt-4">
                        <label htmlFor="lastName" className="block text-sm/6 font-medium text-gray-900">
                            Last Name
                        </label>
                        <div className="mt-2">
                            <div className="flex items-center rounded-md bg-white pl-3 outline outline-1 -outline-offset-1 outline-gray-300 focus-within:outline focus-within:outline-2 focus-within:-outline-offset-2 focus-within:outline-slate-600">
                                <input
                                    id="lastName"
                                    name="lastName"
                                    type="text"
                                    ref={lastName}
                                    placeholder="Enter you last name"
                                    className="block min-w-0 grow py-1.5 pl-1 pr-3 text-base text-gray-900 placeholder:text-gray-400 focus:outline focus:outline-0 sm:text-sm/6"
                                />
                            </div>
                        </div>
                    </div>
                    {/* Age */}
                    <div className="sm:col-span-4 mt-4">
                        <label htmlFor="age" className="block text-sm/6 font-medium text-gray-900">
                            Age
                        </label>
                        <div className="mt-2">
                            <div className="flex items-center rounded-md bg-white pl-3 outline outline-1 -outline-offset-1 outline-gray-300 focus-within:outline focus-within:outline-2 focus-within:-outline-offset-2 focus-within:outline-slate-600">
                                <input
                                    id="age"
                                    name="age"
                                    type="text"
                                    ref={age}
                                    placeholder="Enter you age"
                                    className="block min-w-0 grow py-1.5 pl-1 pr-3 text-base text-gray-900 placeholder:text-gray-400 focus:outline focus:outline-0 sm:text-sm/6"
                                />
                            </div>
                        </div>
                    </div>
                    {/* Save and Reset Button */}
                    <div className="mt-6 flex items-center justify-center gap-x-6">
                        <button type="button" className="border border-black rounded-md px-3 py-2 text-sm font-semibold text-black shadow-sm"
                            onClick={handleFormReset}
                        >
                            Reset
                        </button>
                        <button
                            type="submit"
                            className="rounded-md bg-slate-700 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-slate-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-slate-600"
                        >
                            Save
                        </button>
                        <button
                            type="button"
                            disabled={!isEdit}
                            onClick={handlePersonDelete}
                            className={`rounded-md 
                                ${isEdit ? 'bg-slate-700' : 'bg-slate-500'} 
                                px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-slate-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-slate-600`}
                        >
                            Delete
                        </button>

                    </div>
                </div>
            </form>
        </div>
    )
}

export default Person