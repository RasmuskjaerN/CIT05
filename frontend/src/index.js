import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import SideBoxes from "./sideBoxes";
import DefaultFrontpage from "./DefaultFrontpage";
import reportWebVitals from "./reportWebVitals";
import Login from "./Login";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import App from "./App";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <Router>
      <SideBoxes />
      <App></App>
    </Router>
  </React.StrictMode>
);
reportWebVitals();
