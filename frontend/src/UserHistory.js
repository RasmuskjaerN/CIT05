import React, { useState, useEffect } from "react";
import "./App.css";

function History() {
  const [loading, setLoading] = useState(true);
  const [user, setUser] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const uid = 2;
        const url = `http://localhost:5001/api/user/` + uid;
        const response = await fetch(
          url /*, {
          headers: {
            'Authorization': 'Bearer ' + token
          }
        }*/
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

  console.log(user);
  return (
    <div>
      {error ? (
        <div>{error}</div>
      ) : loading || !user ? (
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
