import { get, post } from "./requests";

export const getLikes = (resourceId) => {
  return get(`like/resource/${resourceId}`, { resourceId })
    .then((response) => response.data);
}


export const likeResource=(resourceId)=>{
    post(`like/resource/like/${resourceId}`,{resourceId});
}

export const dislikeResource=(resourceId)=>{
    post(`like/resource/remove/${resourceId}`,{resourceId});
}

export const likeComment=(commentId)=>{
    post('like/comment/like',{commentId})
}

export const dislikeComment=(commentId)=>{
    post('like/comment/remove',{commentId})
}