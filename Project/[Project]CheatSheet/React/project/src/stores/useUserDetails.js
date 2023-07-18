import { create } from "zustand"
import { getComments } from "../api/Requests/comments";



const useUserDetails = create((set) => ({
    hasDetails:false,
    data:[],
   getUser:async (id) =>{
    try{
        set({isLoading:true});
        const response=await getComments(id);
        set({isLoading:false,data:response.data});
    }
    catch(error){
        console.log(error.message);
    }
   }

  }))

  export default useUserDetails;