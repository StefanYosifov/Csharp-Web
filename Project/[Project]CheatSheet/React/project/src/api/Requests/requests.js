import { getUserData, setUserData } from "../util"
import axios from "axios";

const baseUrl='https://localhost:7273';


const headers={
    'Authorization' : getUserData(),
    'Content-type' : 'application/json'
};

export const get=(endPoint)=>{
  return axios.get(`${baseUrl}/${endPoint}`,{headers});
}

export const post = (endpoint, data) => {
  console.log(data);
  return axios.post(`${baseUrl}/${endpoint}`, data, { headers });
};
