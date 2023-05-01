import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom'
import { GetStatistics } from '../../api/Requests/requests'


const HomePage = () => {
  const [statistics, setStatistics] = useState();


  useEffect(() => {
    GetStatistics()
      .then(data => data)
      .then(res => setStatistics(res.data));
  }, [])

  console.log(statistics);


  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
        <header className="flex flex-col items-center justify-center w-full mb-12">
          {/* <img
            src={logo}
            alt="Logo"
            className="w-64 h-auto object-contain mb-4"
          /> */}
          <h1 className="text-4xl font-bold text-gray-800 text-center">
            Welcome to My Educational Site
          </h1>
          {statistics && (
            <p className="text-lg text-gray-600 mt-4 text-center">
              So far, we've educated over {statistics.usersCount} people with {statistics.resourcesCount} resources available on the platform.
            </p>
          )}
        </header>
        <main className="flex flex-col items-center justify-center w-full">
          <p className="text-2xl font-bold text-gray-800 mb-8 text-center">
            Explore our courses and resources
          </p>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
            <Link
              to="/courses"
              className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-4 px-8 rounded transition duration-200 ease-in-out transform hover:-translate-y-1 hover:scale-110"
            >
              View Courses
            </Link>
            <Link
              to="/resources"
              className="bg-green-500 hover:bg-green-600 text-white font-bold py-4 px-8 rounded transition duration-200 ease-in-out transform hover:-translate-y-1 hover:scale-110"
            >
              View Resources
            </Link>
          </div>
        </main>
      </div>
    </>
  )
}

export default HomePage;
