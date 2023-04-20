import { useNavigate } from "react-router-dom";
import { CategoryItem } from "../Helper components/CategoryItem";
import {v4} from 'uuid'


export const ResourceItem = (props) => {
    const unique_id = v4();
    const resourcers = props.props
    const navigate = useNavigate();
    function navigationHandle(event) {
        event.preventDefault();
        navigate(`/details/${resourcers.id}`)
    }

    return (
        <>
            <div className="max-w-sm rounded overflow-hidden shadow-lg w-10/12 m-8 hover:shadow-2xl">
                <div className="h-96">
                <img className="w-full h-full object-cover" alt="Use any sample image here..." src={resourcers.imageUrl} />
                </div>
                <div className=" text-sm flex bg-gray-700 w-full text-slate-50 justify-evenly h-5">
                    <span>Author: {resourcers.userName}</span>
                    <span>Date: {resourcers.dateTime}</span>
                </div>
                <div className="px-6 py-4 h-52">
                    <div className="font-bold text-xl mb-2">{resourcers.title}</div>
                    <p className="text-gray-700 text-base max-h-36  overflow-hidden text-ellipsis"> {resourcers.content} </p>
                </div>
                <div className="px-4 py-4">
                    {<CategoryItem {...resourcers} key={unique_id}/>}
                </div>

                <div className="flex bg-gray-600 justify-around">
                    <button className="bg-white hover:bg-gray-100 text-gray-800 font-normal py-1 px-2 border border-gray-400 rounded shadow text-sm">
                        Like
                    </button>
                    <button onClick={navigationHandle} className="bg-white hover:bg-gray-100 text-gray-800 font-normal py-1 px-2 border border-gray-400 rounded shadow text-sm ">
                        Details
                    </button>
                    <button className="bg-white hover:bg-gray-100 text-gray-800 font-normal py-1 px-2 border border-gray-400 rounded shadow text-sm">
                        Delete
                    </button>
                </div>

            </div>


        </>
    )
}

export default ResourceItem;