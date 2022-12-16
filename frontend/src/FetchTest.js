import React, {useEffect, useState} from 'react';

export default function FetchTesting(props) {
    const [data, setData] = useState(null);    

      useEffect(() => {
        const fetchData = async () => {
          const response = await fetch(`https://localhost:5001/api/user${props.id}/`);
          const newData = await response.json();
          setData(newData);
        };
    
        fetchData();
      }, [props.id]);


      if (data) {
        return <div>{data.userName}</div>;
      } else {
        return <div>ERROR</div>
        ;
      }
    }
