import {
    useEffect,
    useState,
    type KeyboardEvent,
    type SetStateAction,
} from "react";
import AddedTask from "./AddedTask";
import {
    useCreateTaskMutation,
    useUpdateTaskMutation,
} from "../store/features/Task/taskApiSlice";
import type {
    TaskDetailDataList,
    TaskDetailDto,
    TaskDto,
} from "../models/TaskModel";
import { useAppDispatch } from "../store/hooks/taskHooks";
import { clearTask } from "../store/features/Task/taskSlice";

interface PopupProps {
    open: boolean;
    isEdit: boolean;
    taskData: TaskDto | null;
    onClose: React.Dispatch<SetStateAction<boolean>>;
}

const Popup = ({ open, isEdit, taskData, onClose }: PopupProps) => {
    const [taskTitle, setTaskTitle] = useState<string>("");
    const [taskDescription, setTaskDescription] = useState<string>("");
    const [task, setTask] = useState<string>("");
    const [taskList, setTaskList] = useState<TaskDetailDataList[]>([]);

    const [createTask, { isError, error }] = useCreateTaskMutation();
    const [
        updateTask,
        { isError: isErrorWhileUpdating, error: errorWhileUpdating },
    ] = useUpdateTaskMutation();

    const taskDispatch = useAppDispatch();

    // This useEffect is help with Edit case
    useEffect(() => {
        if (isEdit === true && taskData != null) {
            if (
                taskData != null &&
                taskData.title != null &&
                taskData.title != undefined
            ) {
                setTaskTitle(taskData.title);
            }

            if (
                taskData != null &&
                taskData.description != null &&
                taskData.description != undefined
            ) {
                setTaskDescription(taskData.description);
            }

            if (
                taskData != null &&
                taskData.details != null &&
                taskData.details != undefined
            ) {
                const taskDetailList: TaskDetailDataList[] =
                    taskData.details?.map((d, i) => ({
                        id: d.id ?? i,
                        taskToDo: d.detail ?? "",
                        isCompleted: d.isCompleted,
                    })) ?? [];
                setTaskList(taskDetailList);
            }
        }
    }, [isEdit]);

    if (!open) {
        return null;
    }

    const handleTaskAdd = () => {
        if (task !== "") {
            setTaskList([
                ...taskList,
                { id: 0, taskToDo: task, isCompleted: false },
            ]);
        }
        setTask("");
    };

    const handleTaskDelete = (index: number) => {
        setTaskList((prevItems) => prevItems.filter((_, i) => i !== index));
    };

    const handleKeyDown = (e: KeyboardEvent<HTMLInputElement>) => {
        if (e.key === "Enter") {
            handleTaskAdd();
        }
    };

    function handleCreateOrUpdateTask(): void {
        if (isEdit) {
            if (taskData == null) {
                console.log("Somenthing went wrong in edit");
                return;
            }

            // Task To Do List
            let updatedTaskDetails: TaskDetailDto[] = [];
            if (taskList && taskList.length > 0) {
                updatedTaskDetails = taskList.map((taskDetial) => ({
                    id: taskDetial.id,
                    taskId: taskData.id,
                    detail: taskDetial.taskToDo,
                    isCompleted: taskDetial.isCompleted,
                }));
            }

            // Updated Task
            const updatedTask: TaskDto = {
                id: taskData.id,
                createDate: taskData.createDate,
                category: taskData.category,
                title: taskTitle,
                description: taskDescription === "" ? null : taskDescription,
                details: updatedTaskDetails,
            };

            updateTask(updatedTask);
            reset();
            handlePopupClose();
        } else {
            let newTaskDetails: TaskDetailDto[] = [];

            if (taskList && taskList.length > 0) {
                newTaskDetails = taskList.map((taskDetial) => ({
                    id: taskDetial.id,
                    taskId: 0,
                    detail: taskDetial.taskToDo,
                    isCompleted: false,
                }));
            }

            const newTask: TaskDto = {
                id: 0,
                createDate: new Date(),
                category: 1,
                title: taskTitle,
                description: taskDescription === "" ? null : taskDescription,
                details: newTaskDetails,
            };
            createTask(newTask);
            reset();
            handlePopupClose();
        }
    }

    function handlePopupClose() {
        reset();
        onClose(false);

        if (isEdit === true) {
            taskDispatch(clearTask());
        }
    }

    function reset() {
        setTaskTitle("");
        setTaskDescription("");
        setTask("");
        setTaskList([]);
    }

    if (
        (isError && error != undefined) ||
        (isErrorWhileUpdating && errorWhileUpdating != undefined)
    ) {
        if (error != undefined) {
            console.log(error);
        } else if (errorWhileUpdating != undefined) {
            console.log(errorWhileUpdating);
        }
    }

    return (
        <div className="fixed inset-0 flex items-center justify-center z-50">
            {/* Black overlay start */}
            <div className="fixed inset-0 bg-black/40"></div>
            {/* Black overlay end */}

            {/* Popup box */}
            <div
                className="relative bg-white p-6 rounded-lg shadow-xl z-50 w-[500px] h-auto"
                onClick={(e) => e.stopPropagation()}
            >
                <h2 className="text-xl font-semibold">
                    {isEdit === false ? "New Task" : "Edit Task"}
                </h2>
                <input
                    className="w-full h-10 mt-4 border-2 border-gray-400 placeholder:font-semibold px-2"
                    type="text"
                    placeholder="Title"
                    value={taskTitle}
                    onChange={(e) => setTaskTitle(e.target.value)}
                />
                <input
                    className="w-full h-10 mt-4 border-2 border-gray-400 placeholder:font-semibold px-2"
                    type="text"
                    placeholder="Description (Optional)"
                    value={taskDescription}
                    onChange={(e) => setTaskDescription(e.target.value)}
                />
                {/* Task added start */}
                <AddedTask tasks={taskList} onDelete={handleTaskDelete} />
                {/* Task added end */}
                <div className="mt-4 flex justify-between items-center">
                    <input
                        className="w-[89%] h-10 border-2 border-gray-400 px-2 placeholder:font-semibold focus:border-black outline-none"
                        type="text"
                        placeholder="Write Task to add..."
                        onChange={(e) => setTask(e.target.value)}
                        value={task}
                        onKeyDown={handleKeyDown}
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
                {/* Create or update form button */}
                <div className="mt-4 flex justify-between items-center">
                    <button
                        type="button"
                        className="bg-[#2E2D2F] p-2 border-2 h-10 w-full text-white cursor-pointer"
                        onClick={handleCreateOrUpdateTask}
                    >
                        {isEdit === false ? "Create" : "Update"}
                    </button>
                </div>
                {/* Popup Close Button start */}
                <button
                    className="absolute w-10 h-10 -top-8 -right-12 mt-4 bg-[#2E2D2F] px-2 py-2 rounded-full cursor-pointer"
                    onClick={() => handlePopupClose()}
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
