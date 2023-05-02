
export const getUserData=()=>{
    return (sessionStorage.getItem('Authorization'));
}

export const setUserData=(data)=>{
    const token='Bearer '+data;
    return sessionStorage.setItem('Authorization',token);
}

export const clearUserData=()=>{
    return sessionStorage.removeItem('Authorization');
}

