import React from 'react';
import ReactDOM from 'react-dom';
import { userLoggedIn } from './UserHandler.js';
import './App.css';

class TopBars extends React.Component {
    state = {
      query: '',
      username: '',
      password: ''
    };
  
  
    handleQueryChange = (event) => {
      this.setState({ query: event.target.value });
    }
  
    handleUsernameChange = (event) => {
      this.setState({ username: event.target.value });
    }
  
    handlePasswordChange = (event) => {
      this.setState({ password: event.target.value });
    }
  
    handleLogin = (event) => {
      event.preventDefault();
      // perform login here
    }
  
    render() {
      return (
        <div>
          <div className="topbar">
          <h1>OurMDB</h1>
          <input className='topbar-center'
              type="text"
              placeholder="Search..."
              value={this.state.query}
              onChange={this.handleQueryChange}
            />
            <div>{userLoggedIn ?
              <div>
                <button type="submit">Log out</button>
              </div>:
              <div className= 'topbar-right'>
              <form onSubmit={this.handleLogin}>
                <input
                  type="text"
                  placeholder="Username"
                  value={this.state.username}
                  onChange={this.handleUsernameChange}
                />
                <input
                  type="password"
                  placeholder="Password"
                  value={this.state.password}
                  onChange={this.handlePasswordChange}
                />
                <button type="submit">Signup</button>
                <button type="submit">Login</button>
              </form>
              </div>}
            </div>
          </div>
          <main>
            Test  
          </main>
        </div>
      );
    }
  }
export default TopBars;
