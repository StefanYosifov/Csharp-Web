import {useState} from 'react'

export const CommentForm = ({onSubmit}) => {
    const [comment, setComment] = useState("");
  
    const handleChange = (event) => {
      setComment(event.target.value);
    };
  
    const handleSubmit = (event) => {
      event.preventDefault();
      onSubmit(comment);
      setComment("");
    }
    return (
        <form onSubmit={handleSubmit}>
          <textarea placeholder="Write your comment here" className="w-full rounded-lg shadow-md p-2 mb-4" 
                   onChange={handleChange} value={comment}></textarea>
          <button type="submit" className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Submit</button>
        </form>
      );
    }

export default CommentForm;