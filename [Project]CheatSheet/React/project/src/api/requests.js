import { getUserData, setUserData } from "./util"
import axios from "axios";

const baseUrl='https://localhost:7273';


const headers={
    'Authorization' : getUserData(),
    'Content-type' : 'application/json'
};

export function login(userName,password){

    const data = {
        userName: userName,
        password: password,
      };
    
      axios.post(`${baseUrl}/authenticate/login`, data)
        .then((response) => {
          console.log(response);
          setUserData(response.data.token);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
}

export const getPublicResources=()=>{
  console.log('hi');
    return axios.get(`${baseUrl}/resource`,{headers});
}

export const getDetails=(id)=>{
  console.log(id);
 return axios.get(`${baseUrl}/resource/details/${id}`,{headers})
}


export const addResource=(formData)=>{

    const data={
      "Title":formData.title.toString(),
      "Content":formData.content.toString(),
      "imageUrl":formData.imageUrl.toString(),
      "Categories":{"name":formData.categories}
    }

    console.log(data);
     return axios.post(`${baseUrl}/resource/add`,JSON.stringify(data),{headers})
     .then(res=>console.log(res));
};


export const getCategories=()=>{
 return axios.get(`${baseUrl}/category/get`,{headers});
}