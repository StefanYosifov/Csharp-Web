import { useEffect, useState } from "react";
import { FaCalendarCheck } from "react-icons/fa";
import { getAllTopics } from "../../api/Requests/topics";
import { Link, useParams } from "react-router-dom";

export const CoursePage = (course) => {
    const [expandedItem, setExpandedItem] = useState(null);
    const [topics, setTopics] = useState([]);
    const { id } = useParams();

    const handleItemClick = (index) => {
        if (expandedItem === index) {
            setExpandedItem(null);
        } else {
            setExpandedItem(index);
        }
    };

    useEffect(() => {
        getAllTopics(id).then((res) => { console.log(res.data), setTopics(res.data) });
    }, []);


    console.log(course);
    console.log(topics);
    return (
        <div className="w-full">
            <header className="h-96 bg-blue-400 text-center items-center w-full text-slate-100">
                <span className="bg-blue-100 text-blue-800 mt-6 p-2 text-xs font-medium rounded dark:bg-gray-700 dark:text-blue-400 border border-blue-400">
                    Course
                </span>
                <p className="text-xl">Lorem ipsum dolor sit amet consectetur adipisicing elit. Sint et nihil iste mollitia quae laboriosam non praesentium quibusdam rem voluptas! Quae odio enim quibusdam corrupti voluptate, veritatis reiciendis est. Dicta reiciendis culpa impedit officia placeat! Sapiente numquam, veniam ducimus temporibus perspiciatis magni aut quisquam, eveniet cupiditate, possimus eaque minima aliquid.</p>
                <article className="grid place-items-center text-slate-200 my-8">
                    <section className="w-1/5 grid grid-cols-4 gap-4">
                        <div className="flex items-center col-span-2">
                            <FaCalendarCheck className="text-slate-700" />
                            <span>Start date: 01.01.2023</span>
                        </div>
                        <div className="flex items-center col-span-2">
                            <FaCalendarCheck className="text-slate-700" />
                            <span>End date: 01.02.2023</span>
                        </div>
                    </section>
                </article>
            </header>
            <section className="h-screen bg-slate-100 justify-center flex">
                <div className="w-3/5 rounded bg-red-400 my-16">
                    <p>sdadsa</p>
                    {topics != null ?
                        <>
                            <ul>
                                <li>
                                    <article>
                                        <ul className="grid grid-cols-2 gap-2">
                                            {topics.map((item, index) => (
                                                <li
                                                    key={index}
                                                    className={`border rounded-lg p-4 ${expandedItem === index ? "bg-blue-200" : ""}`}
                                                    onClick={() => handleItemClick(index)}
                                                >
                                                    <div className="flex items-center justify-between cursor-pointer">
                                                        <span>{item.name}</span>
                                                        <span>{expandedItem === index ? "-" : "+"}</span>
                                                    </div>
                                                    {expandedItem === index && (
                                                        <div className="mt-2">
                                                            <Link to={`/course/trainings/videos/${item.videoId}/${item.videoName}`}><span>
                                                            </span>Check out the video for {item.name}
                                                            </Link>
                                                        </div>
                                                    )}
                                                </li>
                                            ))}
                                        </ul>
                                    </article>
                                </li>
                            </ul>
                        </> : <p>No courses</p>}
                </div>
            </section>
        </div>
    )
}