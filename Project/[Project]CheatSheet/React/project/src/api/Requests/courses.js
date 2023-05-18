import { get } from "./requests"




export const getAllCourses=(page)=>{
    return get(`course/all/${page}`);
}