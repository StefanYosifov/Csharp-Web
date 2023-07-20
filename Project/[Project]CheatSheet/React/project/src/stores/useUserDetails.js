import create from "zustand"
import { persist } from "zustand/middleware"
import { login } from "../api/Requests/authentication";

export const useUserDetails = create(persist(
    (set, get) => ({
        user: null,
        isAuthenticated: false,
        login: async (userName, password) => {
            try {
                const response = await login(userName, password);
                const data = response.data;
                if (response.status === 200) {
                    set({ user: data });
                    set({isAuthenticated:true});
                }
                return response;
            } catch (error) {
                console.log(error)
            }
        }
    }),
    {
        name: "user-storage",
        getStorage: () => sessionStorage,
    }
))


