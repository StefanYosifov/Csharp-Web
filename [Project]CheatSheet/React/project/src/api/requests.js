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
 return axios.get(`${baseUrl}/resource/details/${id}`,{headers})
}


export const addResource=(formData)=>{
    console.log(formData);
    const {title,imageUrl,content,categories}=formData;
    console.log(`${title} ${content} ${imageUrl}`);
    // return axios.post(`${baseUrl}/resource/add`,{data},{headers})
};