export const Comments = ({ comment}) => {

  const date = new Date(comment.createdAt);
  const hours = Math.floor(Date.now() / 1000)/60;
  console.log(hours);
  console.log(date);

  console.log(comment);
  
  return (
    <div className="p-4 mt-4 rounded-lg">
      <div className="flex items-center mb-2">
        <img className="w-12 h-12 object-cover rounded-full border border-gray-300" src={comment.userProfileImage} alt={comment.userName} />
        <div className="ml-4">
          <h5 className="text-lg text-gray-800">{comment.userName}</h5>
          <p className="text-sm text-gray-600">{comment.createdAt}</p>
        </div>
      </div>
      <p className="text-gray-800 leading-7 ml-4">{comment.content}</p>
    </div>
  );
  };
  
