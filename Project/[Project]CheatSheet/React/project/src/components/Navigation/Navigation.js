import { NavLink, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { getUserData } from '../../api/util';
import { getUserId } from '../../api/Requests/profile';

function Navigation() {
  const [menuOpen, setMenuOpen] = useState(false);
  const [userId, setUserId] = useState();
  const [isLoggedIn,setIsLoggedIn]=useState(false);
  const navigate = useNavigate();

  useEffect(()=>{
    const token = getUserData();
    if (!token) {
      return setIsLoggedIn(false);
    }
    return setIsLoggedIn(true);
  },[]);

  useEffect(()=>{
      getUserId()
      .then((res)=>{setUserId(res),console.log(res.data)});
  },[isLoggedIn])

  const handleMenuClick = () => {
    setMenuOpen(!menuOpen);
  };



  return (
    <nav className="bg-gray-800">
      <ul className="flex justify-start text-lg items-center py-4 px-6 m-0">
        {!isLoggedIn && (
          <>
            <li>
              <NavLink to="/login" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
                Login
              </NavLink>
            </li>
            <NavLink to="/register" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
              Register
            </NavLink>
          </>
        )}

        {isLoggedIn && (
          <>
            <li>
              <NavLink to="/home" className="text-ellipsis text-white px-2 py-1 rounded-lg hover:bg-red-700 mr-2">
                Home
              </NavLink>
            </li>
            <li>
              <NavLink to="/resources/1" className="text-white px-2 py-1 rounded-lg hover:bg-red-700 mr-2">
                Resource
              </NavLink>
            </li>
            <li>
              <NavLink to="/resource/add" className="text-white px-2 py-1 rounded-lg hover:bg-red-700 mr-2">
                Add
              </NavLink>
            </li>
            <li className="relative">
              <button className="text-white px-2 py-1 rounded-lg hover:bg-red-700 focus:outline-none mr-2" onClick={handleMenuClick}>
                Profile <i className="fas fa-caret-down ml-2"></i>
              </button>
              {menuOpen  && (
                <ul className="absolute right-0 mt-2 py-2 w-40 bg-white rounded-lg shadow-xl">
                  <li>
                    <NavLink to={`/profile/${userId.data}`} className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      My Profile
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="/settings" className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      Settings
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="/logout" className="text-gray-800 hover:bg-red-700 hover:text-white px-3 py-2 rounded-lg block">
                      Logout
                    </NavLink>
                  </li>
                </ul>
              )}
            </li>
          </>
        )}
      </ul>
    </nav>
  );
}

export default Navigation;
