import type { Dispatch, SetStateAction } from "react";

interface ButtonProps {
    text: string;
    path: string | undefined;
    setOpen?: Dispatch<SetStateAction<boolean>>;
}

function Button(props: ButtonProps) {
    const buttonName = props.text;

    const handleButton = () => {
        if (buttonName == "add") {
            props.setOpen?.(true);
        } else {
            props.setOpen?.(false);
        }
    };

    return (
        <button
            type="button"
            className="bg-[#D9D9D9] flex justify-center items-center p-2.5 w-12 h-12 rounded-full"
            onClick={handleButton}
        >
            <img src={props.path} alt={props.text} />
        </button>
    );
}

export default Button;
