import { useNavigate } from "react-router-dom";

export const ResourceItem = (props) => {
    const resourcers = props.props
    console.log(resourcers.id);
    const navigate = useNavigate();


    function navigationHandle(event) {
        event.preventDefault();
        navigate(`/details/${resourcers.id}`)
    }

    return (
        <>
            <div className="resource-item">
                <div className="resource-card">

                    <div className="resource-item-image">
                        <img className="resource-image" src={resourcers.imageUrl} />
                    </div>
                    <div className="resource-info">
                        <div>{resourcers.title}</div>
                        <span>Author: {resourcers.userName}</span>
                        <span>Category: {resourcers.categoryNames.join(', ')}</span>
                        <span>Date: {resourcers.dateTime}</span>
                    </div>
                    <div className="resource-textbox">{resourcers.content}
                    </div>
                    <div className="buttons">
                        <button>Like</button>
                        <button onClick={navigationHandle}>Details</button>
                        <button>Delete</button>
                    </div>

                </div>
            </div>

        </>
    )
}

export default ResourceItem;