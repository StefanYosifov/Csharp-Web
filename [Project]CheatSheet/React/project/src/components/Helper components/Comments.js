export const Comments = ({commentModels}) => {

  console.log(commentModels);
 
  
  return (
    <div className="p-4 mt-4 rounded-lg bg-gray-100 w-full">
      <div className="flex items-center mb-2">
        <img className="w-12 h-12 object-cover rounded-full border border-gray-300" src={commentModels.userProfileImage} alt={commentModels.userName} />
        <div className="ml-4">
          <h5 className="text-lg text-gray-800">{commentModels.userName}</h5>
          <p className="text-sm text-gray-600">{commentModels.createdAt}</p>
        </div>
      </div>
      <p className="text-gray-800 leading-7 ml-4">{commentModels.content}</p>
    </div>
  );
  };
  
