import { useEffect, useState } from "react";
import Button from "./components/Button";
import NoteText from "./components/NoteText";
import SearchField from "./components/SearchField";
import Popup from "./components/Popup";
import Notes from "./components/Notes";
import { useAppSelector } from "./store/hooks/taskHooks";
import { operationsEnums } from "./models/TaskEnums";

function App() {
    const [openAddMenu, setOpenAddMenu] = useState<boolean>(false);
    const [isEdit, setIsEdit] = useState<boolean>(false);
    const taskState = useAppSelector((state) => state.task);

    useEffect(() => {
        if (taskState.operation == operationsEnums.edit) {
            setIsEdit(true);
            setOpenAddMenu(true);
        } else if (taskState.operation == undefined) {
            setIsEdit(false);
        }
    }, [taskState.operation]);

    return (
        <div className="w-full h-screen overflow-y-scroll [scrollbar-width:none] [-ms-overflow-style:none] [&::-webkit-scrollbar]:hidden">
            {/* This NoteText component is fixed compenent on the page */}
            <NoteText />
            <SearchField />
            <div className="absolute right-12 bottom-12 z-50">
                <Button
                    text="add"
                    path={"images/add-item.svg"}
                    setOpen={setOpenAddMenu}
                />
            </div>

            {/* Popup Menu for opening the Add Menu form */}
            {openAddMenu && (
                <Popup
                    open={openAddMenu}
                    isEdit={isEdit}
                    taskData={taskState.value}
                    onClose={setOpenAddMenu}
                />
            )}
            {/* Notes */}
            <Notes />
        </div>
    );
}

export default App;
