import { useEffect, useState } from "react"
import { useParams } from "react-router-dom";
import { getDetails } from "../../api/Requests/details";
import {getComments,sendAComment} from '../../api/Requests/comments'
import { Comments } from '../Helper components/Comments'
import CommentForm from "../Helper components/CommentForm";


export const Detail = () => {
    const [details, setDetails] = useState([]);
    const [comment, setComments] = useState([]);
    const [likes,setLikes]=useState();
    const { id } = useParams();
  
    useEffect(() => {
      getDetails(id).then((res) => setDetails(res.data));
    }, []);
  
    useEffect(() => {
      getComments(id).then((res) => setComments(res.data));
    }, []);

    useEffect(()=>{

    })
  
    const handleSubmitComment = (comment) => {
      sendAComment({ comment, id });
    };

    const handleLike=()=>{
      console.log(details);
    };
  


    return (
        <div className="bg-red-400 min-h-screen flex flex-col justify-between">
        <div className="w-10/12 mx-auto pt-12">
          <div className="flex flex-col items-center bg-gray-200 text-center p-4 rounded-lg shadow-lg">
            <img
              src={details.imageUrl}
              alt="Image"
              className="w-6/12 rounded-lg shadow-md"
            />
            <div className="flex justify-center mt-4">
              <ul className="flex flex-wrap justify-center gap-2">
                {details &&
                  details.categoryNames &&
                  details.categoryNames.map((categoryName) => (
                    <li
                      key={categoryName}
                      className="px-3 py-1 text-gray-700 bg-gray-300 rounded-full"
                    >
                      {categoryName}
                    </li>
                  ))}
              </ul>
            </div>
            <div className="max-w-2xl mt-4">
              <h2 className="text-2xl font-bold mb-2">{details.title}</h2>
              <p className="text-gray-700 leading-7">{details.content}</p>
            </div>
            <button
              className="mt-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
              onClick={handleLike}
            >
              Like
            </button>
          </div>
        </div>
        <div className="mt-4 w-10/12 mx-auto">
          <h3 className="text-lg font-bold mb-2">Add a Comment</h3>
          <CommentForm onSubmit={handleSubmitComment} />
        </div>
        <div className="bg-gray-200 py-4 w-10/12 mx-auto rounded-lg shadow-lg">
          <div className="w-full">
            <h3 className="text-lg font-bold mb-2">Comments</h3>
            <ul className="list-disc">
              {comment &&
                comment.map((comment) => (
                  <Comments key={comment.id} commentModels={comment} />
                ))}
            </ul>
          </div>
        </div>
      </div>
    )};
  
  export default Detail;
  