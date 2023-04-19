import { useState } from "react";
import { addResource } from "../../api/requests";



export const ResourceAdd = () => {
    const [formData, setFormData] = useState({
        "title": "",
        "imageUrl": "",
        "content": ""
    });

    const onChange = (event) => {
        const { name, value } = event.target;
            console.log(name);
            console.log(value);

        setFormData(prevState => ({
            ...prevState,
            [name]: [value]
        }));
    };


    const onSubmit=(event)=>{
        event.preventDefault();
        console.log(formData);
        addResource(formData);
    }
    return (
        <>
            <div className="bg-red-500 w-full flex flex-col min-h-screen justify-center items-center">

                <div className="bg-blue-400 w-9/12">
                    <form onSubmit={onSubmit} className="max-w-md mx-auto">
                        <div className="mb-4">
                            <label htmlFor="title" className="block text-gray-700 font-bold mb-2">
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
                            <label htmlFor="imageUrl" className="block text-gray-700 font-bold mb-2">
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
                            <label htmlFor="content" className="block text-gray-700 font-bold mb-2">
                                Content
                            </label>
                            <textarea
                                id="content"
                                name="content"
                                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                required
                                minLength="3"
                                maxLength="500"
                                rows="6"
                                onChange={onChange}
                            ></textarea>
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