import { decodeToken } from 'react-jwt';
import { getUserData } from '../util'

export const validateToken = () => {
    try{
        const token = getUserData();
        const myDecodedToken = decodeToken(token);
        console.log(`${Date.now()} ${myDecodedToken.exp * 1000}`); 

        if (Date.now() <= myDecodedToken.exp*1000) {
            return true;
        }
        return false;
    }
    catch(error){
        console.log(error);
        return false;
    }
}