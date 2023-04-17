import { useEffect, useState } from "react"
import { getPublicResources } from '../../api/requests'
import ResourceItem from "./ResourceItem";
import SearchBar from "../Helper components/SearchBar";


export function ResourceList() {
  const [resources, setResources] = useState();
  const [isLoading, setIsLoading] = useState(true);


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


  

  

  return (
    <>
      <div className="resource-wrapper">
        <div className="resource-sort">
          <SearchBar/>
          <input type="checkbox"/>
        </div>

      <div className="resource-items">
        {isLoading == true ?
          <p>Is loading</p> : resources.map((x) => <ResourceItem props={x} key={x.id}/>)
        }
      </div>
        </div>

    </>
  )

}