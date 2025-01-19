import PersonDetail from './PersonDetail'
import Person from './Person'
import PersonContextProvider from '../store/person-store'
import { useState } from 'react'

const Container = () => {
    // setting person which is get by clicking row
    const [personData, setPersonData] = useState(null);
    const [updateKey, setUpdateKye] = useState(0);
    const [isEdit, setIsEdit] = useState(false);
    
    function handlePersonDetail(person) {
        if (personData == person) {
            setUpdateKye(prev => prev + 1);
        }
        else {
            setUpdateKye(0);
        }
        setIsEdit(true);
        setPersonData(person);
    }

    return (
        <>
            <div className='w-10/12'>
                <h1 className='font-bold text-xl text-center my-1 text-gray-200'>
                    REACT + .NET CORE CRUD APPLICATION
                </h1>
                <div className='min-h-[550px] bg-white flex'>
                    <PersonContextProvider>
                        {/* PersonDetail contain or list of person */}
                        <PersonDetail sendPersonDataToParent = {handlePersonDetail} />
                        {/* Person contain form */}
                        <Person person = {personData} reRender = {updateKey} edit = {isEdit} />
                    </PersonContextProvider>
                </div>
            </div>
        </>
    )
}

export default Container