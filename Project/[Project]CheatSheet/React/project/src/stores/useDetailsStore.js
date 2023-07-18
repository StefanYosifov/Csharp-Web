import { create } from "zustand"
import { getDetails } from "../api/Requests/details";


const useDetailsStore = create((set) => ({
    isLoading:false,
    data:[],
   getResource:async (id) =>{
    try{
        set({isLoading:true});
        const response=await getDetails(id);
        set({isLoading:false,data:response.data});
    }
    catch(error){
        console.log(error.message);
    }
   }

  }))

  export default useDetailsStore;