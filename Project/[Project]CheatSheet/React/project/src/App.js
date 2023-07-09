import './index.css'
import { Navigation } from './components/Navigation/Navigation';
import { Route, Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import { ResourceList } from './components/Resources/ResourceList';
import { Detail } from './components/Detail/Detail';
import ResourceAdd from './components/Add/ResourceAdd';
import Profile from './components/Profile/Profile'
import {Layout} from "./components/Setup/Layout";
import { Footer } from './components/Footer/Footer';
import { Logout } from './components/Logout/Logout';
import { Privacy } from './components/Static pages/Privacy';
import { TermsAndConditions } from './components/Static pages/Terms and conditions';
import { CoursesList } from './components/Courses/CoursesList';
import { CoursePage } from './components/Courses/CoursePage';
import { CourseVideo } from './components/Courses/CourseVideo';
import { CourseJoin } from './components/Courses/CourseJoin';
import { CourseMy } from './components/Courses/CourseMy';
import { ToastContainer } from 'react-toastify';

import RequireAuth from './components/Setup/RequireAuth';



function App() {
  return (

    <div className="App h-screen">
      <Navigation />
      <Routes>
        <Route path='/' element={<Layout/>}>

          <Route path='/register' Component={RegisterPage} />
          <Route path='/login' Component={LoginPage} />

          <Route element={<RequireAuth />}>
            <Route path='/home' Component={HomePage} />
            <Route path='/logout' Component={Logout} />
            <Route path='/resources/:id' Component={ResourceList} />
            <Route path='/details/:id' Component={Detail} />
            <Route path='/resource/add' Component={ResourceAdd} />
            <Route path='/profile/:id' Component={Profile} />
            <Route path='/privacy' Component={Privacy} />
            <Route path='/terms' Component={TermsAndConditions} />
            <Route path='/course/:id' Component={CoursesList} />
            <Route path='/course/all/:id' Component={CoursesList} />
            <Route path="/course/trainings/:id/:courseTitle" Component={CoursePage} />
            <Route path="/course/trainings/videos/:id/:courseTitle" Component={CourseVideo} />
            <Route path='/course/join/:id' Component={CourseJoin} />
            <Route path='/course/mine/:id' Component={CourseMy} />
          </Route>
        </Route>
      </Routes>
      <Footer />
      <ToastContainer
        position="top-right"
        autoClose={2499}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
      />
    </div>
  );
}

export default App;
