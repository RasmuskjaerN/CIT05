  import React from 'react';
import './App.css';

class DefaultFrontpage extends React.Component {

    state = {
        loading: true,
        movie: null,
        error: null,
    };
    
    async componentDidMount() {
        try {
        const url = `http://localhost:5001/api/movies?page=1&pageSize=26`;
        const response = await fetch(url);
        const data = await response.json(); 
        this.setState({movie: data, loading: false})
        
        } catch (error) {
        this.setState({error: error.message});
        }
    }

    render() {
        console.log(this.state.movie);
        let rank = "";
        return (
          <div>
            {this.state.error ? (
              <div>{this.state.error}</div>
            ) : (
              this.state.loading || !this.state.movie ? (
                <div>Loading...</div>
              ) : (
                <div>
                  <div className='container'>
                    {/* <h1> Top 20 Titles </h1> */}
                    <div className='cards'> 
                      {this.state.movie.items
                        .filter(movie => movie.titleRating.numVotes >= 50)
                        .sort((a, b) => b.titleRating.averageRating - a.titleRating.averageRating)
                        .slice(0, 20)
                        .map((movie, index) => (
                          <div className='card' 
                          key={index}>{rank = (index + 1) + ". "}
                          <img 
                            src= {movie.omdbData.poster}
                            alt="Missing Poster"
                            style={{ width: '80%', borderRadius: '25px', objectFit: 'contain', alignItems: 'center'}}/>
                          {movie.titleRating.averageRating} {/* &#9734; */} - 
                          <h4>{movie.primaryTitle}</h4> ({movie.genre})</div>
                        ))}
                    </div>
<<<<<<< HEAD
                    <div className='box'> 
                      <h1> 20 Random Titles </h1>
                      {this.state.movie.items
                        .sort(() => Math.random() - 0.5)
                        .slice(0, 20)
                        .map((movie, index) => (
                          <div key={index}>{movie.titleRating[0].averageRating} &#9734; - <h4>{movie.primaryTitle}</h4> ({movie.genre})</div>
                        ))}
=======
                    <div className='cards'> 
                      
>>>>>>> 076f01ae7648dfba6ebc880efe2a7ddfcea66e8f
                    </div>
                  </div>
                </div>
              )
            )}
          </div>
        );
      }
}
export default DefaultFrontpage;