import { useEffect, useState } from "react"
import { getMyCourses } from "../../api/Requests/courses";
import { useParams } from "react-router-dom";

export const CourseMy = () => {

    const [courses, setCourses] = useState([]);
    const { id } = useParams();

    useEffect(() => {
        getMyCourses(id).then((res) => setCourses(res.data));
    }, []);


    console.log(courses);
    return (
        <>
        {courses?
            <div className="flex justify-center h-screen">
                <div className="container bg-red-500 m-16 rounded">
                    <article>
                        {courses.map(course => <section className="">{course.title}</section>)}
                    </article>
                </div>
            </div>
        :<p>Awaiting</p>}
        </>
    )
}