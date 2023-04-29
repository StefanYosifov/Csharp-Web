import { useEffect, useState } from "react"
import { getPublicResources } from '../../api/requests'
import ResourceItem from "./ResourceItem";
import SearchBar from "../Helper components/SearchBar";
import { useNavigate } from "react-router-dom";


export function ResourceList() {
  const [resources, setResources] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    getPublicResources()
      .then(response => {
        console.log(response);
        const data = response.data;
        setResources(data);
        console.log(data);
        setIsLoading((state) => state = false);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);


  const onClick = (event) => {
    event.preventDefault();
    console.log(event.target);
    navigate('/resource/add');
  }

  return (
    <>
      <div className="flex flex-col w-full p-10 bg-gray-100">
        <div className="text-center my-2">
          <h2 className="text-4xl font-bold text-gray-800">Enjoying reading our resources?</h2>
        </div>
        <div className="text-center my-2">
          <h2 className="text-3xl font-bold text-gray-800">Why don't you create one?</h2>
        </div>
        <div className="text-center my-2">
          <button onClick={onClick} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-lg shadow-lg">
            Add a Resource
          </button>
        </div>
      </div>

      <div className="flex flex-col w-full p-10">
        <div className="flex justify-center items-center">
          <SearchBar />
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8 mt-8">
          {isLoading ? (
            <p>Loading...</p>
          ) : (
            resources.map((resource) => (
              <ResourceItem key={resource.id} props={resource} />
            ))
          )}
        </div>
      </div>

    </>
  )

}