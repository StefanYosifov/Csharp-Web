import {get,post} from '../Requests/requests'

export const getResourceLikes=()=>{
    return get(`like/resource/all`);
}

export const getPublicResources=()=>{
    return get(`resource`);
}

export const addResource=(formData)=>{
    console.log(formData.categoryIds);
    const data={
        "Title":formData.title.toString(),
        "Content":formData.content.toString(),
        "imageUrl":formData.imageUrl.toString(),
        "categoryIds":formData.categoryIds
      }
  
       return post(`resource/add`,JSON.stringify(data))
       .then(res=>console.log(res));
}