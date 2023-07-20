import { create } from "zustand"
import { getDetails } from "../api/Requests/details";
import { deleteResource } from "../api/Requests/resources";


const useDetailsStore = create((set) => ({
    isLoading: false,
    data: [],
    getResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await getDetails(id);
            set({ isLoading: false, data: response.data });
        }
        catch (error) {
            console.log(error.message);
        }
    },
    deleteResource: async (id) => {
        try {
            set({ isLoading: true });
            const response = await deleteResource(id);
            if (response.status === 200) {
                setData((prevData) => prevData.filter((item) => item.id !== id));
            }
            set({ isLoading: false });
        } catch (error) {
            setIsLoading(false);
        }
    }
})
)

export default useDetailsStore;