import {get,post} from '../Requests/requests'

export const getTotalPages=()=>{
   return get('resource/pages').then(res=>res.data);
}

export const getResourceLikes=()=>{
    return get(`like/resource/all`);
}

export const getPublicResources=(id)=>{
    return get(`resource/${id}`);
}

export const addResource=(formData)=>{
    const data={
        "Title":formData.title.toString(),
        "Content":formData.content.toString(),
        "imageUrl":formData.imageUrl.toString(),
        "categoryIds":formData.categoryIds
      }
  
       return post(`resource/add`,JSON.stringify(data))
       .then(res=>console.log(res));
}