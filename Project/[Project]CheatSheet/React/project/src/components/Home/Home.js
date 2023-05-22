import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom'
import { GetStatistics } from '../../api/Requests/statistics'


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
          <article>

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
                to="/resources/1"
                className="bg-green-500 hover:bg-green-600 text-white font-bold py-4 px-8 rounded transition duration-200 ease-in-out transform hover:-translate-y-1 hover:scale-110"
              >
                View Resources
              </Link>
            </div>
          </article>
          <div className="container mx-auto py-10 px-4 lg:px-0">
            <article className="mb-10">
              <h2 className="text-3xl font-bold mb-4">About Us</h2>
              <p className="text-lg leading-7">
                At Cheat Sheet Project, we believe that software development should be accessible to everyone. Our mission is to provide high-quality educational resources to individuals of all skill levels who are interested in learning how to code.
              </p>
              <p className="text-lg leading-7 mt-4">
                We understand that the world of software development can be overwhelming, especially for beginners. That's why we've created a comprehensive library of cheat sheets, tutorials, and courses that break down complex coding concepts into easy-to-understand chunks.
              </p>
              <p className="text-lg leading-7 mt-4">
                Our team of experienced software developers and educators is committed to providing the most up-to-date information and best practices in the industry. We cover a wide range of topics, from programming languages and frameworks to development tools and techniques.
              </p>
              <p className="text-lg leading-7 mt-4">
                Whether you're a complete beginner or an experienced developer looking to sharpen your skills, Cheat Sheet Project has something for you. Our courses are designed to be flexible, so you can learn at your own pace and on your own schedule.
              </p>
              <p className="text-lg leading-7 mt-4">
                At Cheat Sheet Project, we're passionate about empowering people to learn how to code. We believe that anyone can become a successful software developer with the right resources and support. Join us on this exciting journey and discover the possibilities of software development.
              </p>
            </article>
            <article>
              <h2 className="text-3xl font-bold mb-4">Our History</h2>
              <p className="text-lg leading-7">
                Cheat Sheet Project was founded in 2015 by a group of software developers who wanted to make learning how to code easier and more accessible for everyone. They recognized that traditional programming textbooks and courses could be overwhelming and confusing, especially for beginners.
              </p>
              <p className="text-lg leading-7 mt-4">
                The team started by creating a series of cheat sheets that condensed complex coding concepts into simple, easy-to-understand reference guides. These cheat sheets quickly gained popularity among developers of all skill levels and became the foundation for Cheat Sheet Project's educational resources.
              </p>
              <p className="text-lg leading-7 mt-4">
                As the demand for more comprehensive learning materials grew, Cheat Sheet Project began creating tutorials and courses that covered a wide range of programming languages, frameworks, and development tools. The company's mission was to provide the most up-to-date and relevant information in the industry, while still making it accessible and easy to understand.
              </p>
              <p className="text-lg leading-7 mt-4">
                Today, Cheat Sheet Project has become a leading provider of online educational resources for software development. With a team of experienced developers and educators, we continue to create high-quality content that empowers individuals to learn how to code and pursue careers in tech.
              </p>
              <p className="text-lg leading-7 mt-4">
                We're proud of how far we've come and remain committed to our founding mission of making software development accessible to everyone. Whether you're a complete beginner or an experienced developer, we believe that anyone can learn how to code with the right resources and support. Join us on this exciting journey and discover the possibilities
              </p>
            </article>
          </div>

        </main>
      </div>
    </>
  )
}

export default HomePage;
