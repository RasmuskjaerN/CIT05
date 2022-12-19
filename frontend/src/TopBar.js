import React from 'react';
import { Link } from 'react-router-dom';
import { userLoggedIn } from './UserHandler.js';
import './App.css';
import {useState} from 'react';
import { Router } from 'react-router-dom';

  function TopBars() {

    const [username, setUsername] = useState(""); 
    const [password, setPassword] = useState("");
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
            <Link to="/" style={{ textDecoration: 'none', color: 'inherit'}}><h1>OurMDB{user.uid}</h1></Link>
          <div className='topbar-center'>
              <Link to="/movie"><button type="submit">Search for Movies</button></Link>
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
