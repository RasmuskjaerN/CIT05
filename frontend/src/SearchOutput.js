import React from 'react';
import './App.css';
import userLoggedIn from './UserHandler';
import FetchData from './compTest';

function SearchOut() {
    
    return (
        <div className='page-margin'>
            <FetchData />
        </div>

      );
    }
export default SearchOut;