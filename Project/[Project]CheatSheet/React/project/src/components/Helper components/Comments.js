import { useState } from "react";
import { dislikeComment, likeComment } from "../../api/Requests/likes";


export const Comments = ({ commentModels }) => {
  console.log(commentModels.commentLikes.length);
  const [numLikes, setNumLikes] = useState(commentModels.commentLikes.length);
  const [hasLiked, setHasLikes] = useState(commentModels.hasLiked)


  const handleLikeClick = (event) => {
    event.preventDefault();

    const commentId = commentModels.id;

    if (hasLiked) {
      dislikeComment(commentId)
      setNumLikes((oldLikes) => oldLikes - 1);
    } else {
      likeComment(commentId)
      setNumLikes((oldLikes) => oldLikes + 1);
    }
    setHasLikes(state => !state);
  }

console.log(commentModels);


return (
  <div className="p-4 mt-4 rounded-lg bg-gray-100 w-full">
    <div className="flex items-center mb-2">
      <img className="w-12 h-12 object-cover rounded-full border border-gray-300" src={commentModels.userProfileImage} alt={commentModels.userName} />
      <div className="ml-4">
        <h5 className="text-lg text-gray-800">{commentModels.userName}</h5>
        <p className="text-sm text-gray-600">{commentModels.createdAt}</p>
      </div>
    </div>
    <p className="text-gray-800 break-words ml-4">{commentModels.content}</p>
    <div className="flex justify-end mt-2">
      <button className="text-gray-600 hover:text-gray-800" onClick={handleLikeClick}>
        <span className="ml-1">{numLikes}</span>
      </button>
    </div>
  </div>
);
  };

