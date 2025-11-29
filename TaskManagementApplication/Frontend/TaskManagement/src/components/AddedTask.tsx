interface AddedTaskProps {
    tasks: string[];
    onDelete: (positionOfElement: number) => void
}

const AddedTask = ({ tasks, onDelete }: AddedTaskProps) => {
    return (
        <>
            <div className={`w-full mt-4 outline-none border-2  ${tasks.length > 0 ?  "border-black" : "border-gray-400"} h-80 p-2 text-[#696868] overflow-y-scroll`}>
                {tasks.length > 0 ? (
                    tasks.map((task, index) => (
                        <div
                            key={index}
                            className="group w-full h-9 
                                bg-gray-300 rounded-sm mb-1 px-2
                                flex items-center justify-between hover:bg-[#2E2D2F] duration-300 ease-in"
                        >
                            <p className="text-[1.2em] group-hover:text-white group-hover:duration-300 group-hover:ease-in">
                                {task}
                            </p>
                            <img
                                id={"new-" + index}
                                className="w-6 h-6 r-0
                                    hover:rounded-full hover:bg-white hover:brightness-100 hover:contrast-100 hover:duration-0
                                    group-hover:invert group-hover:brightness-0 group-hover:contrast-200 group-hover:duration-300 group-hover:ease-in"
                                src="images/close.svg"
                                alt="delete image"
                                onClick={() => onDelete(index)}
                            />
                        </div>
                    ))
                ) : (
                    <div>Task not added...</div>
                )}
            </div>
        </>
    );
};

export default AddedTask;
