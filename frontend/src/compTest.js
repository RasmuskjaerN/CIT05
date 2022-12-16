import React, { Component } from "react";

export default class FetchData extends React.Component {

    state = {
        loading: true,
        user: null,
        error: null,
      };
      
      async componentDidMount() {
        try {
          const url = "http://localhost:5001/api/user/2";
          const response = await fetch(url);
          const data = await response.json(); 
          this.setState({user: data, loading: false})
        } catch (error) {
          this.setState({error: error.message});
        }
      }
      
      render() {
        console.log(this.state.user);
        return (
          <div>
            {this.state.error ? (
              <div>{this.state.error}</div>
            ) : (
              this.state.loading || !this.state.user ? (
                <div>Loading...</div> 
              ) : ( 
                <div>
                  <div>{this.state.user.userName}</div>
                </div>
              )
            )}
          </div>
        );
      }
}