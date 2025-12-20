import { operationsEnums } from "../models/TaskEnums";
import type { TaskDto, TaskState } from "../models/TaskModel";
import {
    useDeleteTaskMutation,
    useLazyGetTaskQuery,
} from "../store/features/Task/taskApiSlice";
import { editTask } from "../store/features/Task/taskSlice";
import { useAppDispatch } from "../store/hooks/taskHooks";
import Loader from "./Loader";

interface NoteMenuProps {
    taskId: number;
}

function NoteMenu({ taskId }: NoteMenuProps) {
    // Task Api calls variables
    const [deleteTask, { isLoading, isError, error }] = useDeleteTaskMutation();
    const [
        getTask,
        {
            data,
            isLoading: isFetchingTaskById,
            isError: isErrorFetchingTaskById,
            error: errorFromGettingTask,
        },
    ] = useLazyGetTaskQuery();

    // Task state management calls variables
    const taskDepatch = useAppDispatch();

    function handleTaskDelete(id: number) {
        deleteTask(id);
    }

    async function handleTaskEdit(taskId: number) {
        try {
            const res = await getTask(taskId).unwrap();
            if (res.data != null) {
                const taskDto: TaskDto = res.data;
                const taskState: TaskState = {
                    value: taskDto,
                    operation: operationsEnums.edit
                }
                taskDepatch(editTask(taskState));
            }
        } catch (err) {
            console.error(err);
        }
    };

    if (data != undefined && data != null) {
        console.log(data);
    }

    if (isLoading || isFetchingTaskById) {
        return <Loader />;
    }

    if (isError || isErrorFetchingTaskById) {
        if (error != undefined) {
            console.log(error);
        }
        if (errorFromGettingTask != undefined) {
            console.log(error);
        }
    }

    return (
        <div className={`absolute w-16 h-12 top-3 transition-all`}>
            <ul>
                <li
                    className={`px-1 duration-300 ease-in-out hover:text-white hover:bg-black`}
                    onClick={() => handleTaskEdit(taskId)}
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
