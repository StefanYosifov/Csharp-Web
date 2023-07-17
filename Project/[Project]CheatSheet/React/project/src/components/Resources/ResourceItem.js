import { Link, useNavigate } from "react-router-dom";
import { CategoryItem } from "../Helper components/CategoryItem";
import { FaHeart } from 'react-icons/fa';
const parse = require('html-react-parser');



export const ResourceItem = (props) => {
  const resources = props.props
  const navigate = useNavigate();

  function navigationHandle(event) {
    event.preventDefault();
    navigate(`/details/${resources.id}`)
  }
  
  return (
    <>
      {resources  &&
        <div className="">
          <div className="max-w-lg my-4 bg-white rounded-lg shadow-md hover:shadow-2xl flex flex-col h-full flex-1">
            <div className="flex justify-between items-center bg-gray-700 py-2">
              <span className="text-sm font-light text-gray-50 px-4">Date: {resources.dateTime}</span>
              <div className="flex items-end">
                <span className="text-sm font-light text-gray-50 mr-8 overflow-hidden" >Total likes: {resources.totalLikes}</span>
              </div>
            </div>
            <div className="relative h-64 sm:h-80 border-b border-gray-100">
              <img className="w-full h-full object-cover" src={resources.imageUrl} alt="resourceImage" />
            </div>
            <div className="p-4">
              <h1 className="text-3xl text-gray-700 font-bold hover:text-gray-700 my-2">{resources.title}</h1>
              <div className="text-gray-700 text-base max-h-36 overflow-hidden">{parse(resources.content)}</div>
              <a className="text-blue-600 hover:underline mt-4 inline-block cursor-pointer" onClick={navigationHandle}>Read more</a>
              <Link to={`/details2/${resources.id}`} className="text-blue-600 hover:underline mt-4 inline-block cursor-pointer">Read more</Link>
            </div>
            <div className="flex items-center justify-between p-4 mt-auto">
              <div className="flex items-center">
                <FaHeart size={32} color="red" className="mr-2" />
                {resources.categoryNames.map((category,id) => (
                  <CategoryItem category={category} key={id} />
                ))}
              </div>
              <div className="flex items-center">
                <img className="mx-4 w-10 h-10 object-cover rounded-full hidden sm:block" src={resources.userProfileImage} alt="avatar" />
                <h1 className="text-gray-700 font-bold">{resources.userName}</h1>
              </div>
            </div>
          </div>
        </div>}
    </>

  )
}

export default ResourceItem;