import './index.css'
import Navigation from './components/Navigation/Navigation';
import { Route,Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import * as api from './api/requests';
import { ResourceList } from './components/Resources/ResourceList';
import { Detail } from './components/Detail/Detail';
import ResourceAdd from './components/Add/ResourceAdd';


function App() {

  return (
    <div className="App">
        <Navigation/>
      <Routes>
        <Route path='/home' Component={HomePage}/>
        <Route path='/register' Component={RegisterPage} />
        <Route path='/login' Component={LoginPage} />
        <Route path='/resource' Component={ResourceList} />
        <Route path='/details/:id' Component={Detail} />
        <Route path='/resource/add' Component={ResourceAdd} />

      </Routes>
    </div>
  );
}

export default App;
window.api=api;