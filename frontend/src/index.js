import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import TopBar from "./TopBar";
import SideBoxes from "./sideBoxes";
import DefaultFrontpage from "./DefaultFrontpage";
import reportWebVitals from "./reportWebVitals";
import FetchData from "./Output";
import Login from "./Login";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <Router>
      <SideBoxes />
      <Routes>
        <Route exact path="/" element={<DefaultFrontpage />}></Route>
        <Route exact path="/login" element={<Login />} />
        <Route exact path="/movie" element={<FetchData />}></Route>
      </Routes>
    </Router>
  </React.StrictMode>
);
reportWebVitals();
