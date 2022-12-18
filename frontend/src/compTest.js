import React, { Component } from "react";
import './App.css';
import { userLoggedIn, userAlreadyRated } from './UserHandler.js';

export default class FetchData extends React.Component {

    state = {
        loading: true,
        movie: null,
        error: null,
      };
      
      async componentDidMount() {
        try {
            const id = 'tt10850888';
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
          <div className='page-margin'>
            {this.state.error ? (
              <div>{this.state.error}</div>
            ) : (
              this.state.loading || !this.state.movie ? (
                <div>Loading...</div> 
              ) : ( 
                <div>
                  <div>
                  <h1>{this.state.movie.primaryTitle}</h1>
                
                <div> {/* Extra info bar */}
                {this.state.movie.originalTitle ? (
                    <h4>Original title: {this.state.movie.originalTitle} | </h4>
                    ) : (
                        <h4>Original title: {this.state.movie.primaryTitle} | </h4>
                    )}
                  {this.state.movie.runTimeMinutes ? (
                    <h4>Runtime: {this.state.movie.runTimeMinutes} minutes</h4>
                    ) : (
                        <h4>Runtime unknown.</h4>
                    )}
                    <h4> | Gerne: { this.state.movie.genre}</h4>
                </div>

                    <div className='moive-description'>
                <h3>Featured Actors</h3>
                    Tom Hanks, Sean Kingston, Frank...
                    <hr />
                <h3>Description</h3>
                {this.state.movie.omdbData[0].plot} 
            </div>
                    <img
                    src= {this.state.movie.omdbData[0].poster}
                    alt="Missing Poster"
                    style={{ width: '230px', height: '345px', objectFit: 'contain', display: 'block'}}
                    />
                    <p className='rate'>OurMDB Rating: { this.state.movie.titleRating[0].averageRating } &#9734;</p>

            <div>{userLoggedIn ?
                <div>{userAlreadyRated ?
                    <div>
                        You have already rated this move.
                    </div>:
                    <div>
                        <select>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                        </select>
                        <button type="submit">Rate</button>
                    </div>}
                </div>:
                <div>
                    You must be logged in to rate movies.
                </div>}
            </div>
                  </div>
                </div>
              )
            )}
          </div>
        );
      }
}