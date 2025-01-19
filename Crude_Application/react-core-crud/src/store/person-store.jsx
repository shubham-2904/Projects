import { createContext, useEffect, useState } from "react";

const value = {
    personList: null,
    isLoading: null,
    getAllPerson: () => { },
    savePerson: () => { },
    deletePersonById: () => { },
    updatePerson: () => { }
};

// BASE URL
const BASE_URL = "http://localhost:5013/api/person/"

// This create Context
export const PersonContext = createContext(value);

// Making the PersonContextProvider component
const PersonContextProvider = (props) => {
    // hooks declaration
    const [loading, setLoading] = useState(false);
    const [personList, setPersonList] = useState(null);

    // this useEffect call once when the PersonContext Component mount every time
    useEffect(() => {
        try {
            getAllPerson();
        }
        catch (error) {
            console.log(`Something went wrong ${error}`)
        }
    }, [])

    // Function to get all person from api
    const getAllPerson = () => {
        try {
            setLoading(true);

            const requestOptions = {
                method: "GET",
                redirect: "follow",
            };

            fetch(BASE_URL, requestOptions)
                .then((response) => response.json())
                .then((result) => {
                    if (result != null) {
                        setPersonList(result);
                    }
                    setLoading(false);
                })
                .catch((error) => console.error(error));
        }
        catch (ex) {
            console.log("Somthing went wrong: ", ex);
        }
    }

    // function to save person into DB
    const savePerson = (person) => {
        try {
            const myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            const raw = JSON.stringify(person)

            const requestOptions = {
                method: "POST",
                headers: myHeaders,
                body: raw,
                redirect: "follow"
            };

            fetch(BASE_URL, requestOptions)
                .then((response) => response.text())
                .then((result) => {
                    if (result) {
                        getAllPerson();
                    }
                })
                .catch((error) => console.error(error));
        }
        catch (error) {

        }
    }

    // function to delete person
    const deletePerson = (personId) => {
        const requestOptions = {
            method: "DELETE",
            redirect: "follow"
        };

        fetch(`${BASE_URL}${personId}`, requestOptions)
            .then((response) => response.json())
            .then((result) => {
                if (result.isDelete) {
                    getAllPerson();
                }
            })
            .catch((error) => console.error(error))
    }

    // functio to update person
    const updatePerson = (personId, person) => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        const raw = JSON.stringify(person);

        const requestOptions = {
            method: "PUT",
            headers: myHeaders,
            body: raw,
            redirect: "follow"
        };

        fetch(`${BASE_URL}${personId}`, requestOptions)
            .then((response) => response.json())
            .then((result) => {
                if (result.personUpdate) {
                    getAllPerson();
                }
            })
            .catch((error) => console.error(error))
    }

    return (
        <PersonContext.Provider value={{
            personList: personList,
            loading: loading,
            savePerson: savePerson,
            deletePersonById: deletePerson,
            updatePerson: updatePerson
        }}>
            {props.children}
        </PersonContext.Provider>
    );
}

export default PersonContextProvider;