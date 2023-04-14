import './App.css';
import './styles/style.css'
import { Navigation } from './components/Navigation/Navigation';
import { Route, Router, Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';

function App() {
  return (
    <div className="App">
        <Navigation/>
        <h1>Hello react!</h1>
      <Routes>
        <Route path='/register' Component={RegisterPage} />
        <Route path='/login' Component={LoginPage} />
      </Routes>
    </div>
  );
}

export default App;
