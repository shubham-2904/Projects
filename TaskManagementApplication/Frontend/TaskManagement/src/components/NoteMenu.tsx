import { useDeleteTaskMutation } from "../store/features/Task/taskApiSlice";
import Loader from "./Loader";

interface NoteMenuProps {
    taskId: number;
}

function NoteMenu({ taskId }: NoteMenuProps) {
    const [deleteTask, { isLoading, isError, error }] = useDeleteTaskMutation();
    
    function handleTaskDelete(id: number) {
        deleteTask(id);
    }

    if (isLoading) {
        return <Loader />;
    }

    if (isError) {
        if (error != undefined) {
            console.log(error);
        }
    }

    return (
        <div className={`absolute w-16 h-12 top-3 transition-all`}>
            <ul>
                <li
                    className={`px-1 duration-300 ease-in-out hover:text-white hover:bg-black`}
                    onClick={() => alert("Task Edit Button click")}
                >
                    Edit
                </li>
                <li
                    className={`px-1 duration-300 ease-in-out hover:text-white hover:bg-black`}
                    onClick={() => handleTaskDelete(taskId)}
                >
                    Delete
                </li>
            </ul>
        </div>
    );
}

export default NoteMenu;
