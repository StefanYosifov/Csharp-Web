import { useEffect } from "react";
import useResourceListStore from "../../stores/useResourceListStore"
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { Pagination } from "../Helper components/Pagination";
import ResourceItem from "./ResourceItem";


export const ResourceList2 = () => {
    const { id } = useParams();
    const location = useLocation();
    const navigate = useNavigate()

    const resources = useResourceListStore((state) => state.data);
    const isLoading = useResourceListStore((state) => state.isLoading)
    const resourcesCouint = useResourceListStore((state) => state.pageCount)
    const setResources = useResourceListStore((state) => state.setResourceList);



    useEffect(() => {
        setResources(id, location.search);
    }, [])

    return (
        <>

            {!isLoading && resources &&
                <>
                    <div className="flex flex-col w-full p-10 bg-gray-100">
                        <div className="text-center my-2">
                            <h2 className="text-4xl font-bold text-gray-800">Enjoying reading our resources?</h2>
                        </div>
                        <div className="text-center my-2">
                            <h2 className="text-3xl font-bold text-gray-800">Why don't you create one?</h2>
                        </div>
                        <div className="text-center my-2">
                            <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg shadow-lg">
                                Add a Resource
                            </button>
                        </div>
                    </div>
                    <Pagination
                        currentPage={Number(id)}
                        totalPages={Number(resourcesCouint)}
                        onPageChange={(pageNumber) => navigate(`/resources/${pageNumber}`)}
                    />
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8 mt-8">
                        <ResourceItem></ResourceItem>
                    </div>

                    <Pagination
                        currentPage={Number(id)}
                        totalPages={Number(resourcesCouint)}
                        onPageChange={(pageNumber) => navigate(`/resources/${pageNumber}`)}
                    />
                </>
            }

        </>
    )
}