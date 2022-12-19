import React from 'react';
import ReactDOM from 'react-dom';
import { userLoggedIn } from './UserHandler.js';
import './App.css';
import {useState} from 'react';

  function TopBars() {

    const [username, setUsername] = useState(""); 
    const [password, setPassword] = useState("");
    const [search, setSearch] = useState("");
    const [user, setUser] = useState([]);
    const [status, setStatus] = useState("idle");
    const [uid, setUid] = useState("");
    const [token, setToken] = useState("");

    async function HandleLogin() {
      const loginData = {
        UserName: username,
        Password: password
      };
    
      const options = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginData)
      };
    
      try {
        const response = await fetch('http://localhost:5001/api/user/login', options);
        const json = await response.json();
        setUser(json);
        setStatus('done');
        setUid(user.uid)
        setToken(user.token)
      } catch (e) {
        setStatus('error');
      }
    }

        return (
          <div>
            <div className="topbar">
            <h1>OurMDB{user.uid}</h1>
          <div className='topbar-center'>
            <input 
                type="text"
                placeholder="Search.."
                value={search}
                onChange={e => setSearch(e.target.value)}/>
              <button type="submit">search</button>
              </div>
              <div>{userLoggedIn ?
                <div>
                  <button type="submit">Log out</button>
                </div>:
                <div className= 'topbar-right'>
                <form>
                  <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={e => setUsername(e.target.value)}
                  />
                  <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                  />
                  <button type="submit">Signup</button>
                  <button onClick={HandleLogin} type="button">Login</button>
                </form>
                </div>}
              </div>
              <h1></h1>
            </div>
            <main>
              Test
            </main>
          </div>
        );
    }
  export default TopBars;
