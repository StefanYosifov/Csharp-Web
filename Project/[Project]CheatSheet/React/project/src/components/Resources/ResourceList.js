import { useEffect, useState } from "react"
import { getResourceLikes, getPublicResources, getTotalPages } from '../../api/Requests/resources'
import ResourceItem from "./ResourceItem";
import SearchBar from "../Helper components/SearchBar";
import { Link, useLocation, useNavigate, useParams } from "react-router-dom";
import { Pagination } from "../Helper components/Pagination";
import { getCategories } from "../../api/Requests/categories";
import { DropDown } from "../Helper components/DropDown";


export function ResourceList() {
  const [resources, setResources] = useState();
  const [totalPages, setTotalPages] = useState();
  const [resourceLikes, setResourceLikes] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [category, setCategory] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [searchCategory, setSearchCategory] = useState("");
  const [searchSort, setSearchSort] = useState("");
  const location = useLocation();
  const navigate = useNavigate();

  const sortArray = [
    { id: "0", name: "None" },
    { id: "1", name: "Most liked" },
    { id: "2", name: "Least liked" },
    { id: "3", name: "Most commented" },
    { id: "4", name: "Least commented" },
    { id: "5", name: "Largest content" },
    { id: "6", name: "Smallest content" },
  ];
  const { id } = useParams();


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
    setIsLoading(true);
    getPublicResources(id, location.search)
      .then(response => {
        setResources(response.data);
        setIsLoading((state) => false);
      })
      .catch(error => {
        console.error(error);
      });
  }, [id]);

  useEffect(() => {
    getCategories().then((res) => {
      if (res.status === 200) {
        setCategory((oldCategory) => res.data);
      }
    })
  }, [])


  const handleChange = (state, setStateFunc) => {
    return (event) => {
      setStateFunc(event.target.value);
    };
  };

  const onClick = (event) => {
    event.preventDefault();
    changeUrl();
    getPublicResources(id, location.search)
      .then(response => {
        setResources(response.data);
        setIsLoading((state) => false);
      })
      .catch(error => {
        console.error(error);
      });
  }

  const changeUrl = () => {
    const queryParams = new URLSearchParams(location.search);

    if (searchTerm.length > 0) {
      queryParams.set("search", searchTerm);
    } else {
      queryParams.delete("search");
    }

    if (searchCategory.length > 0) {
      queryParams.set("category", searchCategory);
    } else {
      queryParams.delete("category");
    }
    if (searchSort.length > 0) {
      queryParams.set("sort", searchSort);
    } else {
      queryParams.delete("sort");
    }

    navigate(`${location.pathname}?${queryParams.toString()}`);
  };

  console.log(location);

  console.log(`${searchCategory} ${searchSort}, ${searchTerm}`);
  console.log(`${searchCategory} ${searchSort}, ${searchTerm}`);

  return (
    <>
      {resources && totalPages && id && category && (
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
            <div className="flex justify-self-center items-start">
              <SearchBar searchTerm={searchTerm} handleChange={handleChange(searchTerm, setSearchTerm)} />
              <DropDown category={category} handleChange={handleChange(searchCategory, setSearchCategory)} />
              <DropDown category={sortArray} handleChange={handleChange(sortArray, setSearchSort)} />
              <button type="button" className="inline-block rounded bg-primary px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-norma bg-blue-600 m-2"
                onClick={onClick}>
                Apply filters
              </button>
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