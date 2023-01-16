import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App.js";
import SideBoxes from "./SideBoxes";
import Movie from "./Movie";
import MovieBest from "./MovieBest";
import Pagin from "./Pagin";
import MovieRandom from "./MovieRandom";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import reportWebVitals from "./reportWebVitals";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
    <div>
      <App/>
      <SideBoxes/>
      <Routes>
        <Route exact path="/" element={<Pagin />}></Route>
        <Route exact path="/All" element={<Pagin />}></Route>
        <Route exact path="/Search" element={<Movie />}></Route>
        <Route exact path="/Random" element={<MovieRandom />}></Route>
        <Route exact path="/Best" element={<MovieBest />}></Route>
      </Routes>
    </div>
    </BrowserRouter>
  </React.StrictMode>
  
);
reportWebVitals();
