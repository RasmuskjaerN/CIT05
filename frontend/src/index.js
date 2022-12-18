import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import TopBar from './TopBar';
import SideBoxes from './sideBoxes';
import DefaultFrontpage from './DefaultFrontpage';
import SearchOut from './SearchOutput';
import reportWebVitals from './reportWebVitals';
import FetchTesting from './FetchTest';
import FetchData from './compTest';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
      <TopBar />
      <SideBoxes />
      <DefaultFrontpage />
  </React.StrictMode>
);
reportWebVitals();
