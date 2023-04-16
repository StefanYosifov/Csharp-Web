import './styles/style.css'
import Navigation from './components/Navigation/Navigation';
import { Route,Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import * as api from './api/requests';
import { useEffect, useState } from 'react';
import { ResourceList } from './components/Resources/ResourceList';

function App() {

    

  return (
    <div className="App">
        <Navigation/>
        <h1>Hello react!</h1>
      <Routes>
        <Route path='/home' Component={HomePage}/>
        <Route path='/register' Component={RegisterPage} />
        <Route path='/login' Component={LoginPage} />
        <Route path='/resource' Component={ResourceList} />

      </Routes>
    </div>
  );
}

export default App;
window.api=api;