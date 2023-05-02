export const CategoryItem = (category) => {
    console.log(category);
    const categoryNames = category.categoryNames;
    return (
        <>
            {categoryNames.map(x => <span
                className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2">
                {x}
            </span>)}
        </>
    )
}