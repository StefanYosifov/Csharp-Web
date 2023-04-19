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

  const index=4;
  const myObj={
  'Kiril:BOP-1209':'Fix Minor Bug:ToDo:3',
  'Mariya:BOP-1213':'New Account Page:In Progress:13',
  'Mariya:BOP-1213':'New Account Page:In Progress:13',
  'Mariya:BOP-1213':'New Account Page:In Progress:13',
  'Mariya:BOP-1213':'New Account Page:In Progress:13',
  'Mariya:BOP-1210':'Fix Major Bug:In Progress:3',
  'Peter:BOP-1211':'POC:Code Review:5',
  'Georgi:BOP-1212':'Investigation Task:Done:2',
  'Mariya:BOP-1213':'New Account Page:In Progress:13',
  'Mariya:BOP-1213':'New Account Page:In Progress:13'};



   const newObject={};
   for (const key in myObj) {
    if(!key.includes('Mariya')){
      newObject[key]=myObj[key];
    }
   }



   console.log(newObject);

    const arr=[];
    console.log(Object.entries(myObj).forEach((element,index) => {
      const key=element[0];
      let value=element[1];
      if(key.includes('Mariya')){
        value='';
      }
      arr.push({key,value});
    }));
  

  


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