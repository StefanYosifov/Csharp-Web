import { getUserData,setUserData,clearUserData } from "./util.js";
const host='https://localhost:7273';

async function request(method,url,data){
    const options={
        method,
        headers:{}
    };

    if(data!==undefined){
        options.headers['Content-Type']='Application/json';
        options.body=JSON.stringify(data);
    }
    const user=getUserData();
    console.log(options);
    if(user){
        options.headers['Authorization']=user.accessToken;
    }
    try{
    const response=await fetch(host+url,options);
    console.log(response);
    if(response.status>=400){
        return response;
    }
    const result=await response.json();
    if(response.ok==false){
        throw new Error(response.message);
    }
    return result;
    }
    catch(err){
        alert(err.message);
        throw err;
    }
}


export const get=request.bind(null,'get');
export const post=request.bind(null,'post');
export const put=request.bind(null,'put');
export const del=request.bind(null,'delete');