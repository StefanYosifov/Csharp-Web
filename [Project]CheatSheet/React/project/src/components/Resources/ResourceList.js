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


const onClick=(event)=>{
  event.preventDefault();
  console.log(event.target);
  navigate('/resource/add');
}



  return (
    <>
      <div className="flex flex-col w-full p-10 bg-red-500">
      <div className="text-center my-2">
          <h2>Enjoying seeing our resources?</h2>
        </div>
        <div className="text-center my-2">
          <h2 >Why don't you create one?</h2>
        </div>
        <div className="text-center my-2">
          <button onClick={onClick} className="bg-white hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow w-24">
            Add a resource
          </button>
        </div>
      </div>


      <div className="flex flex-col w-full p-10">
        <div className="flex bg-center">
          <SearchBar />
        </div>

        <div className="flex flex-row justify-evenly bg-slate-50 shadow-sm">
          {isLoading == true ?
            <p>Is loading</p> : resources.map((x) => <ResourceItem props={x} key={x.id} />)
          }
        </div>
      </div>
    </>
  )

}