import Note from "./Note";
import type { colorTheme } from "../utilities/colorTheme";
import {
    useCreateTaskMutation,
    useGetAllTaskQuery,
} from "../store/features/Task/taskApiSlice";
import Loader from "./Loader";

const noteColorPalette: colorTheme[] = [
    // Purple
    {
        bgPrimary: "bg-[#C065FF]",
        bgSecondary: "bg-[#E2C2F8]",
        textPrimary: "text-[#C065FF]",
        textSecondary: "text-[#E2C2F8]",
        textTertory: "text-[#FAFAFA]",
        borderColor: "border-[#C065FF]",
        opacityColor: "bg-[#C065FF]/25",
    },
    // Red
    {
        bgPrimary: "bg-[#FF7987]",
        bgSecondary: "bg-[#FBC0C6]",
        textPrimary: "text-[#FF7987]",
        textSecondary: "text-[#FBC0C6]",
        textTertory: "text-[#FAFAFA]",
        borderColor: "border-[#FF7987]",
        opacityColor: "bg-[#FF7987]/25",
    },
    // Green
    {
        bgPrimary: "bg-[#7CFF6E]",
        bgSecondary: "bg-[#D0FFCB]",
        textPrimary: "text-[#7CFF6E]",
        textSecondary: "text-[#D0FFCB]",
        textTertory: "text-[#FAFAFA]",
        borderColor: "border-[#7CFF6E]",
        opacityColor: "bg-[#7CFF6E]/25",
    },
    // Blue
    {
        bgPrimary: "bg-[#74C0FF]",
        bgSecondary: "bg-[#B7DEFF]",
        textPrimary: "text-[#74C0FF]",
        textSecondary: "text-[#B7DEFF]",
        textTertory: "text-[#FAFAFA]",
        borderColor: "border-[#74C0FF]",
        opacityColor: "bg-[#74C0FF]/25",
    },
];

const Notes: React.FC = () => {
    const {
        data: taskDtoList,
        error,
        isLoading: isFetchingTasks,
    } = useGetAllTaskQuery(undefined, {
        selectFromResult: ({ data, error, isLoading }) => {
            return {
                data: data?.data ?? null,
                error,
                isLoading,
            };
        },
    });

    const [, { isLoading: isCreatingTask }] = useCreateTaskMutation();

    if (error != undefined) {
        console.log(error);
    }

    if (isFetchingTasks || isCreatingTask) {
        return <Loader />;
    }

    return (
        <div className="mx-3 my-5 px-4 grid grid-cols-4 gap-2">
            {taskDtoList &&
                taskDtoList.length > 0 &&
                taskDtoList?.map((task, index) => {
                    let chooseColorIndex = index % noteColorPalette.length;
                    return (
                        <Note
                            key={task.id}
                            task={task}
                            noteTheme={noteColorPalette[chooseColorIndex]}
                        />
                    );
                })}
        </div>
    );
};

export default Notes;
