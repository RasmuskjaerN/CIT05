import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import TopBar from './TopBar';
import SideBoxes from './sideBoxes';
import DefaultFrontpage from './DefaultFrontpage';
import reportWebVitals from './reportWebVitals';
import FetchData from './Output';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
      <TopBar />
      <SideBoxes />
      <FetchData />
  </React.StrictMode>
);
reportWebVitals();
