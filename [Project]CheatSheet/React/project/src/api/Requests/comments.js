import { get, post } from "./requests";


export const getComments=(id)=>{
    return get(`comment/get/${id}`);
  }

export const sendAComment=(comment)=>{
    const data={
      "resourceId":comment.id,
      "Content":comment.comment,
    }
    return post(`comment/send`,data)
    .then((response)=>console.log(response));
  }