import {get,post} from '../Requests/requests'
import { getUserData,setUserData } from '../util';


export const login=(userName,password)=>{

    if(!userName || !password){
        return new Error("Empty");
    }

    return post("authenticate/login", {userName,password})
        .then((response) => {
          console.log(response);
          setUserData(response.data);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
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
  