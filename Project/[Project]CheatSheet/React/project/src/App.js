import './index.css'
import { Navigation } from './components/Navigation/Navigation';
import { Route, Routes } from 'react-router-dom';
import LoginPage from './components/Login/Login';
import RegisterPage from './components/Register/Register';
import HomePage from './components/Home/Home'
import ResourceAdd from './components/Add/ResourceAdd';
import Profile from './components/Profile/Profile'
import { Layout } from "./components/Setup/Layout";
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
import { UserDataProvider } from './context/UserDataProvider';
import { Details2 } from './components/Detail/Details2';

import RequireAuth from './components/Setup/RequireAuth';
import { ResourceList2 } from './components/Resources/ResourceList2';
import { APP_URLS } from './constants/URLConstants';



function App() {
  return (

    <UserDataProvider>
      <div className="App h-screen">
        <Navigation />
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route path={APP_URLS.REGISTER} Component={RegisterPage} />
            <Route path={APP_URLS.LOGIN} Component={LoginPage} />

            <Route element={<RequireAuth />}>
              <Route path={APP_URLS.HOME} Component={HomePage} />
              <Route path={APP_URLS.LOGOUT} Component={Logout} />
              <Route path={APP_URLS.RESOURCES} Component={ResourceList2} />
              <Route path={APP_URLS.DETAILS} Component={Details2} />
              <Route path={APP_URLS.RESOURCES_ADD} Component={ResourceAdd} />
              <Route path={APP_URLS.PROFILE} Component={Profile} />
              <Route path={APP_URLS.PRIVACY} Component={Privacy} />
              <Route path={APP_URLS.TERMS} Component={TermsAndConditions} />
              <Route path={APP_URLS.COURSES} Component={CoursesList} />
              <Route path={APP_URLS.COURSES_ALL} Component={CoursesList} />
              <Route path={APP_URLS.COURSES_TRAININGS} Component={CoursePage} />
              <Route path={APP_URLS.COURSES_VIDEOS} Component={CourseVideo} />
              <Route path={APP_URLS.COURSES_JOIN} Component={CourseJoin} />
              <Route path={APP_URLS.COURSES_MINE} Component={CourseMy} />
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
    </UserDataProvider>
  );

}

export default App;
