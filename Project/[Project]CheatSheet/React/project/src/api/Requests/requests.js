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

export const post = (endPoint, data) => {
  console.log(data);
  return axios.post(`${baseUrl}/${endPoint}`, data, { headers });
};

export const patch=(endPoint,data)=>{
  console.log(data);
  return axios.patch(`${baseUrl}/${endPoint}`,data,{headers});
}

export const del=(endPoint,data)=>{
  console.log(data);
  return axios.delete(`${baseUrl}/${endPoint}`,data,{headers})
}
