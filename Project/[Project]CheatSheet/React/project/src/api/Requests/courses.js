import { get } from "./requests"

export const getAllCourses=(page)=>{
    return get(`course/all/${page}`);
}

export const getCoursePaymentDetails=(id)=>{
    return get(`course/payment/${id}`);
}