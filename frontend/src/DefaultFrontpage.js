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
          const url = `http://localhost:5001/api/movies`;
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
                            <h1> 20 Top Titles </h1>
                            <div>{this.state.movie.items[2].primaryTitle}</div>
                        </div>
                        <div className='box'> 
                            <h1> 20 Random Titles </h1>
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