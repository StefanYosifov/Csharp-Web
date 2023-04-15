import './styles/style.css'
import { Navigation } from './components/Navigation/Navigation';
import { Route, Router, Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import * as api from './api/requests';
import { useEffect, useState } from 'react';

function App() {


    

  return (
    <div className="App">
        <Navigation/>
        <h1>Hello react!</h1>
      <Routes>
        <Route path='/home' Component={HomePage}/>
        <Route path='/register' Component={RegisterPage} />
        <Route path='/login' Component={LoginPage} />
        <Route path='/resources' Component={LoginPage} />

      </Routes>
    </div>
  );
}

export default App;
window.api=api;