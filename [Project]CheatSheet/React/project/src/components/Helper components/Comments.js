export const Comments = ({ comment,createdAt, }) => {
    console.log(comment);
    return (
      <div className="p-4 border border-gray-300 rounded-lg mt-4">
        <h4 className="text-lg font-bold mb-2">asd</h4>
        <p className="text-gray-700 leading-7">{comment.content}</p>
      </div>
    );
  };
  
