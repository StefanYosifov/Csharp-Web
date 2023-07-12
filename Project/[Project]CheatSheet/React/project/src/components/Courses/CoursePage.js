import React, { useEffect, useState } from "react";
import { FaCalendarCheck } from "react-icons/fa";
import { getAllTopics } from "../../api/Requests/topics";
import { Link, useParams } from "react-router-dom";
import { TiWarningOutline, TiSocialYoutube } from "react-icons/ti";
import { Issue } from "../Issue/Issue";

export const CoursePage = () => {
  const [expandedItem, setExpandedItem] = useState(null);
  const [showIssueForm, setShowIssueForm] = useState(false);
  const [topics, setTopics] = useState([]);
  const { id } = useParams();

  useEffect(() => {
    getAllTopics(id).then((res) => {
      setTopics(res.data);
    });
  }, []);

  const handleItemClick = (index) => {
    if (expandedItem === index) {
      setExpandedItem(null);
    } else {
      setExpandedItem(index);
    }
  };

  const handleShowIssueForm = (e) => {
    e.preventDefault();
    setShowIssueForm((res)=>res=!showIssueForm); 
  };

  console.log(topics);
  return (
    <div className="w-full">
      <section className="h-screen bg-slate-100 justify-center flex">
        <div className="w-4/5 rounded bg-red-400 my-16">
          <p>sdadsa</p>
          {topics != null ? (
            <>
              <ul>
                <li>
                  <article>
                    <ul className="grid grid-cols-2 gap-2">
                      {topics.map((item, index) => (
                        <li
                          key={index}
                          className={`border rounded-lg p-4 ${
                            expandedItem === index ? "bg-blue-200" : ""
                          }`}
                          onClick={() => handleItemClick(index)}
                        >
                          <div className="flex items-center justify-between cursor-pointer">
                            {showIssueForm && <Issue showIssue={true}topicId={item.id} />}
                            <span>{item.name}</span>
                            <span>{expandedItem === index ? "-" : "+"}</span>
                          </div>
                          {expandedItem === index && (
                            <div className="">
                              <div className="flex items-center">
                                <TiSocialYoutube className="mr-2" />
                                <Link
                                  to={`/course/trainings/videos/${item.videoId}/${item.videoName}`}
                                >
                                  <span>Video for {item.name}</span>
                                </Link>
                              </div>
                              <div className="flex items-center" onClick={handleShowIssueForm}>
                                <TiWarningOutline className="mr-2" />
                                <span>Report an issue</span>
                              </div>
                            </div>
                          )}
                        </li>
                      ))}
                    </ul>
                  </article>
                </li>
              </ul>
            </>
          ) : (
            <p>No courses</p>
          )}
        </div>
      </section>
    </div>
  );
};