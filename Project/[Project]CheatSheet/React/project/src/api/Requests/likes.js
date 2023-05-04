import { get, post } from "./requests";


export const likeComment=(commentId)=>{
    post('like/comment/like',{commentId})
}

export const dislikeComment=(commentId)=>{
    post('like/comment/remove',{commentId})
}