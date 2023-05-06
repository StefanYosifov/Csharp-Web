import {get,post} from '../Requests/requests'


export const getProfileData=(userId)=>{
    return get(`profile/${userId}`).then((res)=>res.data);
}

export const getUserId=()=>{
    return get('profile/myuserId')
}