import { toast } from 'react-toastify';
import { get, post, postWithoutNotification } from '../Requests/requests'
import { getUserData, setUserData, setUserStorage } from '../util';
import 'react-toastify/dist/ReactToastify.css';



export const login = (userName, password) => {

  if (!userName || !password) {
    return Promise.reject(new Error("Empty"));
  }

  return postWithoutNotification("authenticate/login", { userName, password })
    .then((response) => {
      if (response.status === 200) {
        setUserData(response.data);
        toast.success(`You have successfully logged in!`);
        setUserData(response.data);
      }
      return response.status;
    }).catch((error) => {
      toast.error(error.response.data);
    });
}



export const register = (userData) => {
  return postWithoutNotification("authenticate/register", userData)
    .then((response) => {
      if (response.status === 200) {
        setUserData(response.data);
        toast.success(`You have successfully registered!`);
      }
    })
    .catch((error) => {
      toast.error(`There was an error when registering!`);
      return Promise.reject(error);
    });
}
