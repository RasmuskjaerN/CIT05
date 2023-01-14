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
                    <div className='box'> 
                      <h1> Top 20 Titles </h1>
                      {this.state.movie.items
                        .filter(movie => movie.titleRating[0].numVotes >= 500)
                        .sort((a, b) => b.titleRating[0].averageRating - a.titleRating[0].averageRating)
                        .slice(0, 20)
                        .map((movie, index) => (
                          <div key={index}>{movie.titleRating[0].averageRating} &#9734; - <h4>{movie.primaryTitle}</h4> ({movie.genre})</div>
                        ))}
                    </div>
                    <div className='box'> 
                      <h1> 20 Random Titles </h1>
                      {this.state.movie.items
                        .sort(() => Math.random() - 0.5)
                        .slice(0, 20)
                        .map((movie, index) => (
                          <div key={index}>{movie.titleRating[0].averageRating} &#9734; - <h4>{movie.primaryTitle}</h4> ({movie.genre})</div>
                        ))}
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