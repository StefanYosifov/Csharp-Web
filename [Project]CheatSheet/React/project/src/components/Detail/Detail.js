import { useEffect, useState } from "react"
import { useParams } from "react-router-dom";
import { getDetails } from "../../api/requests";


export const Detail=()=>{


    const[details,setDetails]=useState([]);
    const {id}=useParams();
    console.log(id);
    console.log('hi');

    useEffect(()=>{
        getDetails(id)
        .then(res=>setDetails(res.data));
    },[])

    console.log(details);
    return(
        <>
            <div className="bg-yellow-500">
              <img src={details.imageUrl} alt="detail-image" />
              <p>{details.content}</p>
            </div>
        </>
    )
}


export default Detail;