
export const getUserData=()=>{
    return (localStorage.getItem('Authorization'));
}

export const setUserData=(data)=>{
    const token='Bearer '+data;
    return localStorage.setItem('Authorization',token);
}

export const clearUserData= ()=>{
    return  localStorage.removeItem('Authorization');
}

