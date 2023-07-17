import { useNavigate, useParams } from "react-router-dom";
import { getDetails } from "../../api/Requests/details";
import { useFetch } from "../../hooks/useFetch"
import { useContext, useEffect, useReducer, useState, } from "react";
import { FaThumbsUp, FaComment } from 'react-icons/fa';
import { UserContext } from "../../context/UserDataProvider";
import { dislikeComment, dislikeResource, likeResource } from "../../api/Requests/likes";
const parse = require('html-react-parser');


/*const ACTION = {
    UPDATE: "update",
    INCREASE: "increase",
    DECREASE: "decrease",
    CHANGE_HasLiked: "change"
}*/

const ACTIONS = {
    CALL_API: 'call-api',
    SUCCESS: 'success',
    ERROR: 'error',

    UPDATE: "update",
    INCREASE: "increase",
    DECREASE: "decrease",
};

const reducer = (state, action) => {
    switch (action.type) {
        case ACTIONS.CALL_API: {
            return {
                ...state,
                loading: true,
            };
        }
        case ACTIONS.SUCCESS: {
            return {
                ...state,
                loading: false,
                detailsState: action.data,
            };
        }
        case ACTIONS.ERROR: {
            return {
                ...state,
                loading: false,
                error: action.error,
            };
        }
        case ACTIONS.INCREASE: {
            return {
                ...state,
                detailsState: {
                    ...state.detailsState,
                    likes: state.detailsState.likes + 1,
                    hasLiked: !state.detailsState.hasLiked
                },
                loading: false,
                error: action.error,
            };
        }

        case ACTIONS.DECREASE: {
            return {
                ...state,
                detailsState: {
                    ...state.detailsState,
                    likes: state.detailsState.likes - 1,
                    hasLiked: !state.detailsState.hasLiked
                },
                loading: false,
                error: action.error,
            };
        }
        default:
            return state;
    }
}




const initialState = {
    detailsState: '',
    loading: false,
    error: null,
};

export const Details2 = () => {
    const { id } = useParams();
    let navigate = useNavigate();
    const [user, setUser] = useContext(UserContext);

    const [state, dispatch] = useReducer(reducer, initialState);
    const { detailsState, loading, error } = state;

    useEffect(() => {
        dispatch({ type: ACTIONS.CALL_API });
        const details = async () => {
            let response = await getDetails(id);
            if (response.status == 200) {
                dispatch({ type: ACTIONS.SUCCESS, data: response.data });
                return;
            }
            dispatch({ type: ACTIONS.ERROR, error: response.error });
        };

        details();
    }, []);

    const likeResource = () => {
        likeResource(id).then((res) => {
            if (res.status === 200) {
                dispatch({ type: ACTIONS.INCREASE, payload: { resourceId: id } });
            }
        })
    };

    const dislikeResource = () => {
        dislikeResource(id).then((res) => {
            if (res.status === 200) {
                dispatch({ type: ACTIONS.INCREASE, payload: { resourceId: id } });
            }
        })
    };

    return (
        <>
            <div>
                {loading ? (
                    <p>loading...</p>
                ) : error ? (
                    <p>{error}</p>
                ) : ((
                    <div className="bg-red-400 min-h-screen flex flex-col justify-between">
                        <div className="w-10/12 mx-auto pt-12">
                            <div className="flex flex-col items-center bg-gray-200 text-center p-4 rounded-lg shadow-lg">
                                <img
                                    src={detailsState.imageUrl}
                                    alt="Image"
                                    className="w-6/12 rounded-lg shadow-md mb-4"
                                />
                                <div className="flex items-center text-xs mb-4">
                                    <div className="flex items-center mr-4">
                                        <div className="rounded-full p-2 mr-2 bg-blue-500">
                                            <FaThumbsUp size={20} className="text-white" />
                                        </div>
                                        <span className="text-gray-700">{detailsState.likes} Likes</span>
                                    </div>
                                    <div className="flex items-center">
                                        <div className="rounded-full p-2 mr-2 bg-blue-500">
                                            <FaComment size={20} className="text-white" />
                                        </div>
                                        <span className="text-gray-700">{[detailsState.resourceComments].length} Comments</span>
                                    </div>
                                </div>
                                <div className="flex justify-center mb-4">
                                    <ul className="flex flex-wrap justify-center gap-2">
                                        {detailsState &&
                                            detailsState.categoryNames &&
                                            detailsState.categoryNames.map((categoryName) => (
                                                <li
                                                    key={categoryName}
                                                    className="px-3 py-1 text-gray-700 bg-gray-300 rounded-full"
                                                >
                                                    {categoryName}
                                                </li>
                                            ))}
                                    </ul>
                                </div>
                                <div className="max-w-2xl mb-4">
                                    <h2 className="text-2xl font-bold mb-2">{detailsState.title}</h2>
                                    {parse(String(detailsState.content).toString())}
                                </div>
                                <div className="flex justify-between w-full">
                                    {detailsState.hasLiked ? (
                                        <button
                                            className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded mr-2"
                                            onClick={dislikeResource}
                                        >
                                            Dislike
                                        </button>
                                    ) : (
                                        <button
                                            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2"
                                            onClick={likeResource}
                                        >
                                            Like
                                        </button>
                                    )}
                                    <div>
                                        {detailsState.userId === user?.userId ? <>
                                            <button
                                                className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded mr-2"
                                            >
                                                Edit
                                            </button>
                                            <button
                                                className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded"

                                            >
                                                Delete
                                            </button>
                                        </>
                                            : ""}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </div>


        </>
    )
}