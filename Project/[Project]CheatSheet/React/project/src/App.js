import './index.css'
import Navigation from './components/Navigation/Navigation';
import { Route,Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import { ResourceList } from './components/Resources/ResourceList';
import { Detail } from './components/Detail/Detail';
import ResourceAdd from './components/Add/ResourceAdd';
import Profile from './components/Profile/Profile'
import { Footer } from './components/Footer/Footer';
import { Logout } from './components/Logout/Logout';
import { useEffect, useState } from 'react';
import { getUserData } from './api/util';
import { getUserId } from './api/Requests/profile';
import { Privacy } from './components/Static pages/Privacy';
import { TermsAndConditions } from './components/Static pages/Terms and conditions';


function App() {
  return (
  
    <div className="App">
        <Navigation/>
      <Routes>
        <Route path='/home' Component={HomePage}/>
        <Route path='/register' Component={RegisterPage} />
        <Route path='/login' Component={LoginPage} />
        <Route path='/logout' Component={Logout}/>
        <Route path='/resources/:id' Component={ResourceList} />
        <Route path='/details/:id' Component={Detail} />
        <Route path='/resource/add' Component={ResourceAdd} />
        <Route path='/profile/:id' Component={Profile} />
        <Route path='/privacy' Component={Privacy}/>
        <Route path='/terms' Component={TermsAndConditions} />
      </Routes>
      <Footer/>
    </div>
    
  );
}

export default App;
