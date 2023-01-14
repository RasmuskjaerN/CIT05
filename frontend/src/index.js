import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App.js";
import SideBoxes from "./SideBoxes";

import reportWebVitals from "./reportWebVitals";


const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <div>
      <App/>
      <SideBoxes/>
    </div>
  </React.StrictMode>
);
reportWebVitals();