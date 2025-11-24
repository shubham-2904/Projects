import { useState } from "react";
import Button from "./components/Button";
import NoteText from "./components/NoteText";
import SearchField from "./components/SearchField";
import Popup from "./components/Popup";
import { Provider } from "react-redux";
import { store } from "./store/taskStore";

function App() {
    const [openAddMenu, setOpenAddMenu] = useState<boolean>(false);
    return (
        <div className="w-screen h-screen">
            {/* This NoteText component is fixed compenent on the page */}
            <NoteText />
            <SearchField />
            <div className="absolute right-12 bottom-12">
                <Button
                    text="add"
                    path={"images/add-item.svg"}
                    setOpen={setOpenAddMenu}
                />
            </div>

            {/* Popup Menu for opening the Add Menu form */}
            {openAddMenu && (
                <Provider store={store}>
                    <Popup
                        open={openAddMenu}
                        onClose={() => setOpenAddMenu(false)}
                    />
                </Provider>
            )}
        </div>
    );
}

export default App;
