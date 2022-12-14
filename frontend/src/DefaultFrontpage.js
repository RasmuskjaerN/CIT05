import React from 'react';
import './App.css';

class DefaultFrontpage extends React.Component {

render() {
return (
    <div className='container'>
        <div className='box'> 
            <h1> Top 50 Movies </h1>
        </div>
        <div className='box'> 
            <h1> Top 50 Actors </h1>
        </div>
    </div>
);
}

}
export default DefaultFrontpage;