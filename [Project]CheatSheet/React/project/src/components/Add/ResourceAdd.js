import { useEffect, useState } from "react";
import { addResource, getCategories } from "../../api/requests";



export const ResourceAdd = () => {
    const [formData, setFormData] = useState({
        "title": "",
        "imageUrl": "",
        "content": "",
        "categories": []
    });

    const [categories, setCategories] = useState([]);

    useEffect(() => {
        getCategories()
            .then(response => setCategories(response.data))

    }, []);

    console.log(categories);

    const handleCategoryChange = (event) => {
        const { value } = event.target;
        const isChecked = event.target.checked;

        setFormData(prevState => {
            if (isChecked) {
                return {
                    ...prevState,
                    categories: [...prevState.categories, value],
                };
            } else {
                return {
                    ...prevState,
                    categories: prevState.categories.filter(category => category !== value),
                };
            }
        });
    };


    const onChange = (event) => {
        const { name, value } = event.target;

        setFormData(prevState => ({
            ...prevState,
            [name]: [value]
        }));
    };


    const onSubmit = (event) => {
        event.preventDefault();
        addResource(formData);
    }
    return (
        <>
        <div className=" w-full flex flex-col min-h-screen justify-center items-center">
            <div className="bg-slate-50 w-8/12 h-full border rounded-md shadow-lg">
                <form onSubmit={onSubmit} className="max-w-md mx-auto">
                    <div className="mb-4">
                        <label htmlFor="title" className="block text-lg text-gray-700 font-bold my-2">
                            Title
                        </label>
                        <input
                            id="title"
                            name="title"
                            type="text"
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            required
                            minLength="3"
                            maxLength="50"
                            onChange={onChange}
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="imageUrl" className="block text-lg text-gray-700 font-bold mb-2">
                            Image URL
                        </label>
                        <input
                            id="imageUrl"
                            name="imageUrl"
                            type="text"
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            onChange={onChange}
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="content" className="block text-lg text-gray-700 font-bold mb-2">
                            Content
                        </label>
                        <textarea
                            id="content"
                            name="content"
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            required
                            minLength="3"
                            rows="12"
                            onChange={onChange}
                        ></textarea>
                    </div>
                    <div className="my-4">
                        <span className="block text-gray-700 font-bold mb-2">Categories:</span>
                        <div className="grid grid-cols-2 gap-4">
                            {categories.map(category => (
                                <div key={category.id} className="flex items-center">
                                    <input
                                        type="checkbox"
                                        name="categories"
                                        value={category.name}
                                        checked={formData.categories.includes(category.name)}
                                        onChange={handleCategoryChange}
                                        className="mr-2"
                                    />
                                    <label className="text-base text-gray-700">{category.name}</label>
                                </div>
                            ))}
                        </div>
                    </div>
                    <div className="flex items-center justify-between">
                        <button
                            type="submit"
                            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        >
                            Save
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </>
    )
}

export default ResourceAdd;