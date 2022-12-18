import React, { Component } from "react";
import './App.css';

export default class FetchData extends React.Component {

    state = {
        loading: true,
        movie: null,
        error: null,
      };
      
      async componentDidMount() {
        try {
            const id = 'tt11361862';
          const url = `http://localhost:5001/api/movies/` + id;
          const response = await fetch(url);
          const data = await response.json(); 
          this.setState({movie: data, loading: false})
        } catch (error) {
          this.setState({error: error.message});
        }
      }
      
      render() {
        console.log(this.state.movie);
        return (
          <div>
            {this.state.error ? (
              <div>{this.state.error}</div>
            ) : (
              this.state.loading || !this.state.movie ? (
                <div>Loading...</div> 
              ) : ( 
                <div>
                  <div>
                  <h1>{this.state.movie.primaryTitle}</h1>
                  {this.state.movie.runTimeMinutes ? (
                    <h4>Runtime: {this.state.movie.runTimeMinutes} minutes</h4>
                    ) : (
                        <h4>Runtime unknown.</h4>
                    )}
                    <h4>Gerne: {this.state.movie.genre}</h4>
                  </div>
                </div>
              )
            )}
          </div>
        );
      }
}