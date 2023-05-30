import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getCoursePaymentDetails } from "../../api/Requests/courses";

export const CourseJoin = () => {

    const [course, setCourse] = useState();
    const { id } = useParams();

    useEffect(() => {
        getCoursePaymentDetails(id).then((res) => {
            if (res.status !== 200) {
                return;
            }
            setCourse(() => res.data);
        })
    }, []);

    console.log(course);

    return (
        course !== null ? (
            <div className="bg-gray-100 min-h-screen flex flex-col items-center justify-center">
                <div className="max-w-md w-full mx-auto p-8 bg-white rounded-lg shadow-md">
                    <h2 className="text-3xl font-semibold mb-4">Join React with Tailwind Course</h2>
                    <form action="#" method="POST" className="space-y-4">
                        <div>
                            <label htmlFor="name" className="text-gray-700">Name:</label>
                            <input type="text" id="name" name="name" className="w-full border-gray-300 rounded-md px-4 py-2 mt-2 focus:outline-none focus:border-blue-500" required />
                        </div>
                        <div>
                            <label htmlFor="email" className="text-gray-700">Email:</label>
                            <input type="email" id="email" name="email" className="w-full border-gray-300 rounded-md px-4 py-2 mt-2 focus:outline-none focus:border-blue-500" required />
                        </div>
                        <div>
                            <label htmlFor="message" className="text-gray-700">Message:</label>
                            <textarea id="message" name="message" className="w-full border-gray-300 rounded-md px-4 py-2 mt-2 focus:outline-none focus:border-blue-500" rows="4" required></textarea>
                        </div>
                        <div>
                            <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600">Join Now</button>
                        </div>
                    </form>
                </div>
            </div>
        ) : (
            <p>There was an error</p>
        )
    );
}


