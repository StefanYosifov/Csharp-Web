import { NavLink, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { getUserData } from '../../api/util';
import { getUserId } from '../../api/Requests/profile';

function Navigation() {
  const [menuOpen, setMenuOpen] = useState(false);
  const [userId, setUserId] = useState();
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const token = getUserData();
    if (!token) {
      return setIsLoggedIn(false);
    }
    return setIsLoggedIn(true);
  }, []);

  useEffect(() => {
    getUserId()
      .then((res) => { setUserId(res), console.log(res.data) });
  }, [isLoggedIn])

  const handleMenuClick = () => {
    setMenuOpen(!menuOpen);
  };



  return (
    <nav className="bg-gray-800">
      <ul className="flex justify-start text-lg items-center py-4 px-6 m-0">
        <div className="text-lg font-bold md:py-0 py-4">
          Logo
        </div>
        {!isLoggedIn && (
          <>
            <li>
              <NavLink to="/login" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
                Login
              </NavLink>
            </li>
            <li>
              <NavLink to="/register" className="text-white px-2 py-1 rounded-lg hover:bg-red-700">
                Register
              </NavLink>
            </li>
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
            <ul className="md:px-2 ml-auto md:flex md:space-x-2 absolute md:relative top-full left-0 right-0">
              <li>
                <a href="#" className="flex md:inline-flex p-4 items-center hover:bg-gray-50">
                  <span>Home</span>
                </a>
              </li>
              <li>
                <a href="#" className="flex md:inline-flex p-4 items-center hover:bg-gray-50">
                  <span>Resources</span>
                </a>
              </li>
              <li className="relative group">
                <div className="flex justify-between md:inline-flex p-4 items-center hover:bg-gray-50 space-x-2">
                  <span>Courses</span>
                  <svg xmlns="http://www.w3.org/2000/svg" className="w-4 h-4 fill-current pt-1" viewBox="0 0 24 24">
                    <path d="M0 7.33l2.829-2.83 9.175 9.339 9.167-9.339 2.829 2.83-11.996 12.17z" />
                  </svg>
                </div>
                <ul className="absolute top-full right-0 hidden md:block w-48 bg-white shadow-lg rounded-b opacity-0 transform -translate-y-10 group-hover:opacity-100 group-hover:translate-y-0 transition duration-300">
                <li>
                    <NavLink to="course/all/1" className="flex px-4 py-3 hover:bg-gray-50">
                      All
                    </NavLink>
                  </li>
                  <li>
                  <NavLink to="course/C#" className="flex px-4 py-3 hover:bg-gray-50">
                      C#
                   </NavLink>
                  </li>
                  <li>
                    <NavLink to="course/Java" className="flex px-4 py-3 hover:bg-gray-50">
                      Java
                    </NavLink>
                  </li>
                  <li>
                    <NavLink to="course/Python" className="flex px-4 py-3 hover:bg-gray-50">
                      Python
                      </NavLink>
                  </li>
                  <li>
                  <NavLink to="resource/Javascript" className="flex px-4 py-3 hover:bg-gray-50">
                      JavaScript
                    </NavLink>
                  </li>
                </ul>
              </li>
              <li>
                <NavLink to="about" className="flex md:inline-flex p-4 items-center hover:bg-gray-50">
                  <span>About us</span>
                </NavLink>
              </li>
            </ul>
            <li className="relative">
              <button className="text-white px-2 py-1 rounded-lg hover:bg-red-700 focus:outline-none mr-2" onClick={handleMenuClick}>
                Profile <i className="fas fa-caret-down ml-2"></i>
              </button>
              {menuOpen && (
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
