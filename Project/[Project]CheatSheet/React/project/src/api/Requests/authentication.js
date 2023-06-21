import {get,post} from '../Requests/requests'
import { getUserData,setUserData, setUserStorage } from '../util';


export const login=(userName,password)=>{

  if(!userName || !password){
      return Promise.reject(new Error("Empty"));
  }

  return post("authenticate/login", {userName,password})
      .then((response) => {
        console.log(response);
        setUserData(response.data);
        return response.status;
      })
}


export const register = (userData) => {
    return post("authenticate/register", userData)
      .then((response) => {
        console.log(response);
        setUserData(response.data);
      })
      .catch((error) => {
        console.error("Error:", error);
        return Promise.reject(error);
      });
  }
  