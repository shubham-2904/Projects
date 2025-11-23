import { useState } from "react";
import AddedTask from "./AddedTask";

interface PopupProps {
    open: boolean;
    onClose: () => void;
}

const Popup = ({ open, onClose }: PopupProps) => {
    const [task, setTask] = useState<string>("");
    const [taskList, setTaskList] = useState<string[]>([]);

    if (!open) {
        return null;
    }


    const handleTaskAdd = () => {
        if (task !== "") {
            setTaskList([...taskList, task]);
        }
        setTask("");
    };

    const handleTaskDelete = (index: number) => {
        setTaskList(prevItems => prevItems.filter((_, i) => i !== index));
    }

    return (
        <div className="fixed inset-0 flex items-center justify-center z-50">
            {/* Black overlay start */}
            <div className="fixed inset-0 bg-black/40"></div>
            {/* Black overlay end */}

            {/* Popup box */}
            <div
                className="relative bg-white p-6 rounded-lg shadow-xl z-50 w-[500px] h-[600px]"
                onClick={(e) => e.stopPropagation()}
            >
                <h2 className="text-xl font-semibold">New Task</h2>
                <input
                    className="w-full h-10 mt-4 border-2 placeholder:font-semibold px-2"
                    type="text"
                    placeholder="Title"
                />
                <input
                    className="w-full h-10 mt-4 border-2 placeholder:font-semibold px-2"
                    type="text"
                    placeholder="Description (Optional)"
                />
                {/* Task added start */}
                <AddedTask tasks={taskList} onDelete={handleTaskDelete} />
                {/* Task added end */}
                <div className="mt-4 flex justify-between items-center">
                    <input
                        className="w-[89%] h-10 border-2 px-2 placeholder:font-semibold"
                        type="text"
                        placeholder="Write Task to add..."
                        onChange={(e) => setTask(e.target.value)}
                        value={task}
                    />
                    {/* new task add button */}
                    <button
                        type="button"
                        className="bg-[#2E2D2F] p-2 border-2 w-10 h-10 rounded-full cursor-pointer"
                        onClick={handleTaskAdd}
                    >
                        <img
                            className="invert brightness-0 contrast-200"
                            src="images/add-item.svg"
                            alt="add svg"
                        />
                    </button>
                    {/* new task add button */}
                </div>
                {/* Popup Close Button start */}
                <button
                    className="absolute w-10 h-10 -top-8 -right-12 mt-4 bg-[#2E2D2F] px-2 py-2 rounded-full cursor-pointer"
                    onClick={onClose}
                >
                    <img
                        className="invert brightness-0 contrast-200"
                        src="images/close.svg"
                        alt="add svg"
                    />
                </button>
                {/* Popup Close Button end */}
            </div>
        </div>
    );
};

export default Popup;
