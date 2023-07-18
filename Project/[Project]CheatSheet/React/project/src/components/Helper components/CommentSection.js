import { useEffect, useState } from "react";
import useCommentsStore from "../../stores/useCommentsStore"
import { useParams } from "react-router-dom";
import { BiLike, BiDislike, BiHeart } from "react-icons/bi";



export const CommentSection = () => {
    const { id } = useParams();
    const comments = useCommentsStore((state) => state.data);
    const getComments = useCommentsStore((state) => state.getAllComments);
    const updateComment = useCommentsStore((state) => state.updateComment);
    const likeComment = useCommentsStore((state) => state.likeAComment);
    const dislikeComment = useCommentsStore((state) => state.dislikeAComment);


    const [editingCommentId, setEditingCommentId] = useState(null);
    const [editCommentContent, setEditCommentContent] = useState("");

    const handleEditClick = (commentId, commentContent) => {
        setEditingCommentId(commentId);
        setEditCommentContent(commentContent);
    };

    const handleSaveClick = (commentId) => {
        updateComment(commentId, editCommentContent);

        setEditingCommentId(null);
        setEditCommentContent("");
    };


    useEffect(() => {
        getComments(id);
    }, [getComments, id]);


    return (
        <>
            <h2 className="text-lg font-bold mb-4">Comments</h2>
            <div className="flex flex-col space-y-4 mx-12">
                {comments.map((comment, index) => (
                    <div key={index} className="bg-white p-4 rounded-lg shadow-md">
                        {console.log(comment)}
                        <img src={comment.userProfileImage} className="object-cover w-12 h-12 border-2 border-gray-300 rounded-full"/>
                        <h3 className="text-lg font-serif">{comment.userName}</h3>
                        <p className="text-gray-700 text-sm mb-2">Posted on {comment.createdAt}</p>
                        {editingCommentId === comment.id ? (
                            <>
                                <textarea
                                    value={editCommentContent}
                                    onChange={(e) => setEditCommentContent(e.target.value)}
                                    className="border border-gray-300 p-2 mb-2"
                                />
                                <button
                                    onClick={() => handleSaveClick(comment.id)}
                                    className="bg-blue-500 text-white py-2 px-4 rounded-lg"
                                >
                                    Save
                                </button>
                            </>
                        ) : (
                            <p className="text-gray-700">{comment.content}</p>
                        )}
                        <div className="">
                            <div className="flex py-1">
                                {!comment.hasLiked ? (
                                    <span className="text-green-500 mr-1"
                                    onClick={() => likeComment(comment.id)}
                                    >
                                        <BiLike />
                                    </span>
                                ) : (
                                    <span className="text-red-500 mr-1"
                                    onClick={() => dislikeComment(comment.id)}
                                    >
                                        <BiDislike />
                                    </span>
                                )}
                                <span>{comment.likeCount}</span>
                            </div>
                        </div>
                        {!editingCommentId && (
                            <button
                                onClick={() => handleEditClick(comment.id, comment.content)}
                                className="bg-yellow-500 text-white py-1 px-2 rounded-lg mt-2"
                            >
                                Edit
                            </button>
                        )}
                    </div>
                ))}
            </div>
        </>
    )
}