import { useNavigate } from "react-router-dom";
import { CategoryItem } from "../Helper components/CategoryItem";
import { FaHeart } from 'react-icons/fa';


export const ResourceItem = (props) => {
  const resourcers = props.props
  const navigate = useNavigate();
  console.log(resourcers);
  function navigationHandle(event) {
    event.preventDefault();
    navigate(`/details/${resourcers.id}`)
  }




  return (
    <>
      {resourcers  &&
        <div className="">
          <div className="max-w-lg my-4 bg-white rounded-lg shadow-md hover:shadow-2xl flex flex-col h-full flex-1">
            <div className="flex justify-between items-center bg-gray-700 py-2">
              <span className="text-sm font-light text-gray-50 px-4">Date: {resourcers.dateTime}</span>
              <div className="flex items-end">
                <span className="text-sm font-light text-gray-50 mr-8 overflow-hidden" >Total likes: {resourcers.likes}</span>
              </div>
            </div>
            <div className="relative h-64 sm:h-80 border-b border-gray-100">
              <img className="w-full h-full object-cover" src={resourcers.imageUrl} alt="resourceImage" />
            </div>
            <div className="p-4">
              <h1 className="text-3xl text-gray-700 font-bold hover:text-gray-700 my-2">{resourcers.title}</h1>
              <p className="text-gray-700 text-base max-h-36 overflow-hidden">{resourcers.content}</p>
              <a className="text-blue-600 hover:underline mt-4 inline-block cursor-pointer" onClick={navigationHandle}>Read more</a>
            </div>
            <div className="flex items-center justify-between p-4 mt-auto">
              <div className="flex items-center">
                <FaHeart size={32} color="red" className="mr-2" />
                {resourcers.categoryNames.map((category,id) => (
                  <CategoryItem category={category} key={id} />
                ))}
              </div>
              <div className="flex items-center">
                <img className="mx-4 w-10 h-10 object-cover rounded-full hidden sm:block" src={resourcers.userProfileImage} alt="avatar" />
                <h1 className="text-gray-700 font-bold">{resourcers.userName}</h1>
              </div>
            </div>
          </div>
        </div>}
    </>

  )
}

export default ResourceItem;