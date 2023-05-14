import { useEffect, useState } from "react"
import { getResourceLikes, getPublicResources, getTotalPages } from '../../api/Requests/resources'
import ResourceItem from "./ResourceItem";
import SearchBar from "../Helper components/SearchBar";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Pagination } from "../Helper components/Pagination";


export function ResourceList() {
  const [resources, setResources] = useState();
  const [totalPages, setTotalPages] = useState();
  const [resourceLikes, setResourceLikes] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const navigate = useNavigate();
  const { id } = useParams();


console.log(resources);

  useEffect(() => {
    getTotalPages().then((res) => {
      setTotalPages(res)
    });
  }, []);


  useEffect(() => {
    getResourceLikes()
      .then(response => {
        setResourceLikes(response);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    getPublicResources(id)
      .then(response => {
        setResources(response.data);
        setIsLoading((state) => state = false);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);


  useEffect(() => {
    setIsLoading(true); 
    getPublicResources(id)
      .then(response => {
        setResources(response.data);
        setIsLoading(false); 
      })
      .catch(error => {
        console.error(error);
      });
  }, [id]);

  console.log(totalPages);
  const onClick = (event) => {
    event.preventDefault();
    navigate('/resource/add');
  }

  return (
    <>
    {resources && totalPages && id && (
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

      <Pagination
          currentPage={Number(id)}
          totalPages={Number(totalPages)}
          onPageChange={(pageNumber) => navigate(`/resources/${pageNumber}`)}
        />

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
        <Pagination
          currentPage={Number(id)}
          totalPages={Number(totalPages)}
          onPageChange={(pageNumber) => navigate(`/resources/${pageNumber}`)}
        />
      </div>
      </>
    )}
    </>
  )

}