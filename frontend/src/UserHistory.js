import React, { useState, useEffect } from "react";
import useLocalStorage from "./useLocalStorage";
import "./App.css";

function History() {
  const [loading, setLoading] = useState(true);
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);
  const [uid, setUid] = useLocalStorage("uid","");
  const [token, setToken] = useLocalStorage("token", "");

  useEffect(() => {
    async function fetchData() {
      try {
        const url = `http://localhost:5001/api/user/` + uid;
        const response = await fetch(
          url , {
          headers: {
            'Authorization': 'Bearer ' + token
          }
        }
        );
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
      ) : loading || !uid ? (
        <div>Loading...</div>
      ) : (
        <div>
          {user.histories.slice(-10).map((history, index) => (
            <div key={index}>
              {history.historyDate} | {history.historySearchInput}
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default History;
