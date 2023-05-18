import { useEffect, useState } from "react";
import { getAllCourses } from "../../api/Requests/courses";
import { CoursesItem } from "./CoursesItem";
import { useParams } from "react-router-dom";


export const CoursesList = () => {

    const [courses, setCourses] = useState([]);
    const {id}=useParams();

    console.log(id);

    useEffect(() => {
        getAllCourses(id).then((res) => setCourses(() => res.data));
    }, []);

    return (
        <div className="container mx-auto">
          <div className="grid grid-cols-2 gap-8 mt-8">
            {courses.map((course, id) => (
              <CoursesItem key={id} course={course} />
            ))}
          </div>
        </div>
      );
}