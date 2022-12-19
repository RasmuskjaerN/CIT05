import React, { useState, useEffect } from "react";
import './App.css';
import { userLoggedIn, userAlreadyRated } from './UserHandler.js';

function FetchData() {
  const [loading, setLoading] = useState(true);
  const [movie, setMovie] = useState(null);
  const [error, setError] = useState(null);
  const [search, setSearch] = useState("");
  const [tconst, setTconst] = useState('tt10850888');

  useEffect(() => {
    async function fetchMovie() {
      try {
        const url = `http://localhost:5001/api/movies/` +tconst;
        const response = await fetch(url);
        if (!response.ok) {
          setTconst('tt10850888');
          return;
        }
        const data = await response.json(); 
        setMovie(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
      }
    }

    fetchMovie();
  }, [tconst]);

  console.log(movie);
  return (
    <div className='page-margin'>
      {error ? (
        <div>{error}</div>
      ) : (
        loading || !movie ? (
          <div>Loading...</div> 
        ) : ( 
          <div>
            <div>
            <div>
            <input 
                type="text"
                placeholder="Search.."
                value={search}
                onChange={e => setSearch(e.target.value)}/>
              <button onClick={() => setTconst(search)} type="submit">Search</button>
              </div>
              <h1>{movie.primaryTitle}</h1>

              <div> {/* Extra info bar */}
                {movie.originalTitle ? (
                  <h4>Original title: {movie.originalTitle} | </h4>
                ) : (
                  <h4>Original title: {movie.primaryTitle} | </h4>
                )}
                {movie.runTimeMinutes ? (
                  <h4>Runtime: {movie.runTimeMinutes} minutes</h4>
                ) : (
                  <h4>Runtime unknown.</h4>
                )}
                <h4> | Gerne: { movie.genre}</h4>
              </div>
              <div className='moive-description'>
                <h3>Featured Actors</h3>
                actor list is missing.
                <hr />
                <h3>Description</h3>
                {movie.omdbData[0].plot} 
              </div>
              <img
                src= {movie.omdbData[0].poster}
                alt="Missing Poster"
                style={{ width: '230px', height: '345px', objectFit: 'contain', display: 'block'}}
              />
              <p className='rate'>OurMDB Rating: { movie.titleRating[0].averageRating } &#9734;</p>

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

export default FetchData;
