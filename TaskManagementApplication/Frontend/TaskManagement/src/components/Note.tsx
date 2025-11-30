import type { colorTheme } from "../utilities/colorTheme";

interface noteProps {
    noteTheme: colorTheme
}

const Note: React.FC<noteProps> = ({noteTheme}) => {
    return (
        <div className={`relative ml-5 px-3 w-[20rem] h-[22em] ${noteTheme?.bgSecondary}`}>
            {/* Date and category */}
            <div className="mt-2 flex items-center justify-between text-[12px]">
                <p className={`${noteTheme.textPrimary}`}>Date: 27/10/2025</p>
                <p className={`p-0.5 w-12 rounded-lg text-center text-[12px] ${noteTheme.textSecondary} ${noteTheme.bgPrimary}`}>
                    Task
                </p>
            </div>
            {/* Title */}
            <div className="mt-2">
                <h1 className={`text-4xl ${noteTheme.textPrimary}`}>Title</h1>
            </div>
            {/* Description */}
            <div className="mt-2">
                <h3 className={`text-2xl ${noteTheme.textPrimary}`}>Description...</h3>
            </div>
            {/* List of note or task */}
            <div className="mt-2">
                <ul className={`flex items-center justify-between ${noteTheme.opacityColor} ${noteTheme.textTertory} mb-2 px-3 duration-300 ease-in-out hover:scale-105 hover:cursor-pointer`}>
                    <p><s>List of task</s></p>
                    <div className="flex items-center p-1">
                        <button className={`${noteTheme.bgPrimary} rounded-full w-6 h-6 p-1`}>
                            <img
                                className="invert brightness-0 contrast-200
                                hover:scale-125 duration-300 ease-in-out"
                                src="images/edit.svg"
                                alt="Edit"
                            />
                        </button>
                        <button className={`${noteTheme.bgPrimary} rounded-full w-6 h-6 p-1 ml-2`}>
                            <img
                                className="invert brightness-0 contrast-200
                                hover:scale-125 hover:duration-300 hover:ease-in-out"
                                src="images/delete.svg"
                                alt="Delete"
                            />
                        </button>
                    </div>
                </ul>
            </div>
            {/* Edit Task Note Menu */}
            <div className={`absolute w-3 h-3 border-2 ${noteTheme.borderColor} rounded-full ${noteTheme.bgSecondary} -top-2 -right-4`}>
                <img src="images/menu-dots.svg" alt="" />
            </div>
        </div>
    );
};

export default Note;
