import { useState } from "react";
import Button from "./components/Button";
import NoteText from "./components/NoteText";
import SearchField from "./components/SearchField";
import Popup from "./components/Popup";
import Notes from "./components/Notes";

function App() {
    const [openAddMenu, setOpenAddMenu] = useState<boolean>(false);

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
                    onClose={() => setOpenAddMenu(false)}
                />
            )}
            {/* Notes */}
            <Notes />
        </div>
    );
}

export default App;
