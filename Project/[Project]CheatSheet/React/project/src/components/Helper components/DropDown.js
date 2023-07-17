export const DropDown = ({ category,value, handleChange }) => {
    return (
        <div className="w-72 m-2">
            <select
                className="inline-flex hover:bg-gray-50inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
                label="Select Version"
                animate={{
                    mount: { y: 0 },
                    unmount: { y: 25 },
                }}
                value={value}
                onChange={handleChange}>
                {Object.values(category).map((ctg) => (
                    <option
                        key={ctg.id}
                        className="absolute right-0 z-10 mt-2 w-56 origin-top-right divide-y divide-gray-100 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                        {ctg.name}
                    </option>
                ))}</select>
        </div>
    )
}
