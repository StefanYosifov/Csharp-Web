import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';

function Navigation() {
  const [menuOpen, setMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <nav>
      <ul>
        <li>
          <NavLink to="/home">Home</NavLink>
        </li>
        <li>
          <NavLink to="/login">Login</NavLink>
        </li>
        <li>
          <NavLink to="/register">Register</NavLink>
        </li>
        <li>
          <NavLink to="/resource">Resource</NavLink>
        </li>
        <li className="profile-tab">
          <button className="profile-btn" onClick={handleMenuClick}>
            Profile
            <i className="fas fa-caret-down"></i>
          </button>
          {menuOpen && (
            <ul className="dropdown-menu">
              <li>
                <NavLink to="/profile">My Profile</NavLink>
              </li>
              <li>
                <NavLink to="/settings">Settings</NavLink>
              </li>
              <li>
                <NavLink to="/logout">Logout</NavLink>
              </li>
            </ul>
          )}
        </li>
      </ul>
    </nav>
  );
}

export default Navigation;
