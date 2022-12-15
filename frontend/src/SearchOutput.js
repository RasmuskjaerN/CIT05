import React from 'react';
import './App.css';
import userLoggedIn from './UserHandler';

function SearchOut() {

    const userAlreadyRated = false;
    
    return (
        <div className='page-margin'>
            <h2>Movie Title Here</h2>
            <img
            src="https://www.amazon.com/images/M/MV5BZjNlZmUyYmMtNjNjMS00NzQ5LTlmYjktNDVkMmRjMTQyMmVjXkEyXkFqcGdeQXVyNzk0NTA5NQ@@._V1_SX300.jpg?"
            alt="Missing Poster"
            style={{ width: '230px', height: '345px', objectFit: 'contain', display: 'block'}}
            />
            <p className='rate'>OurMDB Rating: 5.4 &#9734;</p>
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

            <div className='moive-description'>
                <h3>Featured Actors</h3>
                    Tom Hanks, Sean Kingston, Frank...
                    <hr />
                <h3>Description</h3>
                Here there will be a description of the movie plot woop woop!
            </div>
        </div>

      );
    }
export default SearchOut;