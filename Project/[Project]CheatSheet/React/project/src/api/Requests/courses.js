import { get, post } from "./requests"

export const getAllCourses = (page, language, price) => {
    language = language === undefined ? '' : language;
    price = price === undefined ? '' : price;

    return get(`course/all/${page}?language=${language}&price=${price}`);
}

export const getCoursePaymentDetails = (id) => {
    return get(`course/payment/${id}`);
}

export const getCoursesLanguages = () => {
    return get(`course/languages`);
}
export const joinCoursePayment = (id) => {
    return post(`course/payment/${id}`);
}
