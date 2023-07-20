import { useNavigate, useParams } from "react-router-dom";
import { getDetails } from "../../api/Requests/details";
import { useFetch } from "../../hooks/useFetch"
import { useContext, useEffect, useReducer, useState, } from "react";
import { FaThumbsUp, FaComment } from 'react-icons/fa';
import { UserContext } from "../../context/UserDataProvider";
import useDetailsStore from "../../stores/useDetailsStore";
import useCommentsStore from "../../stores/useCommentsStore";
import CommentForm from "../Helper components/CommentForm";
import { CommentSection } from "../Helper components/CommentSection";
import { useUserDetails } from "../../stores/useUserDetails";
const parse = require('html-react-parser');



export const Details2 = () => {
    const { id } = useParams();

    const details = useDetailsStore((state) => state.data);
    const getDetails = useDetailsStore((state) => state.getResource);
    const deleteDetails = useDetailsStore((state) => state.deleteResource);

    const comments = useCommentsStore((state) => state.data);
    const getComments = useCommentsStore((state) => state.getAllComments);


    const user = useUserDetails((state) => state.user);

    const navigate = useNavigate();

    useEffect(() => {
        getDetails(id);
        getComments(id);
        console.log(details);
    }, []);

    const handleDeleteResource = () => {
        deleteDetails(id);
        navigate('/resources/1', {
            replace: true,
            exact: true,
        });
    }


    function showResource() {
        return(
            <div className="w-10/12 pt-12">
      <div className="flex flex-col items-center bg-slate-100 text-center p-4 rounded-lg shadow-lg">
        <img
          src={details.imageUrl}
          alt="Image"
          className="w-6/12 rounded-lg shadow-md mb-4"
        />
        <div className="flex items-center text-xs mb-4">
          <div className="flex items-center mr-4">
            <div className="rounded-full p-2 mr-2 bg-blue-500">
              <FaThumbsUp size={20} className="text-white" />
            </div>
            <span className="text-gray-700">{details.likes} Likes</span>
          </div>
          <div className="flex items-center">
            <div className="rounded-full p-2 mr-2 bg-blue-500">
              <FaComment size={20} className="text-white" />
            </div>
            <span className="text-gray-700">{comments.length} Comments</span>
          </div>
        </div>
        <div className="flex justify-center mb-4">
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
        <div className="max-w-2xl mb-4 dark:text-primary-50">
          <h2 className="text-2xl font-bold mb-2">{details.title}</h2>
          {parse(String(details.content).toString())}
        </div>
        <div className="flex justify-between w-full">
          <button
            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2"
          >
            Like
          </button>
          <div>
            {details.userId === user.userId ? (
              <>
                <button
                  className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded mr-2"
                >
                  Edit
                </button>
                <button
                  className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded"
                  onClick={handleDeleteResource}
                >
                  Delete
                </button>
              </>
            ) : ""}
          </div>
        </div>
      </div>
    </div>
        )
    }

    return (
        <>
            <div className=" flex flex-col justify-between items-center">
                {showResource()}
                <CommentForm />
                <CommentSection />
            </div>
        </>
    )
}
