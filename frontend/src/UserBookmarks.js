
import React, { useState, useEffect } from 'react';
import './App.css';
import useLocalStorage from "./useLocalStorage";

function Bookmarks() {
  const [loading, setLoading] = useState(true);
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);
  const [uid, setUid] = useLocalStorage("uid"," ");
  const [token, setToken] = useLocalStorage("token", " ");

  useEffect(() => {
    async function fetchData() {
      try {
        if(uid === "undefined" || token === "undefined"){
          setError = "login needed";
          return;
        }
        const url = `http://localhost:5001/api/user/` + uid;
        const response = await fetch(url, {
          headers: {
            'Authorization': 'Bearer ' + token
          }
        });
        const data = await response.json(); 
        setUser(data);
        setLoading(false);
        
        
      } catch (error) {
        setError(error.message);
      }
    }
    fetchData();
  }, []);

  console.log(uid);
  return (
    <div>
      {error ? (
        <div>{error}</div>
      ) : (
        loading || !uid ? (
          <div>Loading...</div>
        ) : (
          <div>
            {user.bookmarks
              .slice(-10)
              .map((bookmark, index) => (
                <div key={index}>{bookmark.bookmarkTconst}, Note: {bookmark.bookmarkNote }</div>
              ))}
          </div>
        )
      )}
    </div>
  );
}

export default Bookmarks;