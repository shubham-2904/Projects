import Button from "./Button";

const SearchField: React.FC = () => {
    return (
        <div className="w-[50%] pt-5 flex justify-around ml-auto mr-auto">
            <input
                className="w-[90%] mr-1.5 h-12 px-6 bg-[#D9D9D9] rounded-3xl placeholder:font-semibold"
                type="text"
                placeholder="Search..."
            />
            <div className="rounded-3xl">
                <Button text="search" path={"images/search.svg"} />
            </div>
        </div>
    );
};

export default SearchField;
