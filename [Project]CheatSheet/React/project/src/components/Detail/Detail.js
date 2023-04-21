import { useEffect, useState } from "react"
import { useParams } from "react-router-dom";
import { getDetails } from "../../api/requests";
import { CategoryItem } from "../Helper components/CategoryItem";
import { Comments } from '../Helper components/Comments'


export const Detail = () => {


    const [details, setDetails] = useState([]);
    const { id } = useParams();



    useEffect(() => {
        getDetails(id)
            .then(res => setDetails(res.data));

    }, [])

    console.log(details);
    console.log(details.comments);



    return (
        <div className="w-10/12 mx-auto pt-12">
            <div className="flex flex-col items-center bg-gray-200 text-center p-4 rounded-lg shadow-lg py-4">
                <img src={details.imageUrl} alt="Image" className="w-6/12 rounded-lg shadow-md" />
                <div className="flex justify-center mt-4">
                    <ul className="flex flex-wrap justify-center gap-2">
                        {details && details.categoryNames && details.categoryNames.map((categoryName) => (
                            <li key={categoryName} className="px-3 py-1 text-gray-700 bg-gray-300 rounded-full">{categoryName}</li>
                        ))}
                    </ul>
                </div>
                <div className="max-w-2xl mt-4">
                    <h2 className="text-2xl font-bold mb-2">{details.title}</h2>
                    <p className="text-gray-700 leading-7">{details.content}</p>
                </div>
                <div className="max-w-2xl mt-4">
                    <h3 className="text-lg font-bold mb-2">Comments</h3>
                    <ul className="list-disc pl-4">
                        {details && details.comments && details.comments.map(comment => <Comments key={comment.id} comment={comment} />)}
                        <li className="text-gray-700">Comment 1</li>
                        <li className="text-gray-700">Comment 2</li>
                    </ul>
                </div>
            </div>
        </div>
    )
}


export default Detail;