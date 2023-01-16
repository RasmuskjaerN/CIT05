import "bootstrap/dist/css/bootstrap.min.css";
import {
  Navbar,
  Container,
  Nav,
  Form,
  FormControl,
  Button,
  Col,
  Row,
  NavDropdown,
} from "react-bootstrap";
import { useState } from "react";
import Pagin from "./Pagin";
import MovieBest from "./MovieBest";
import MovieRandom from "./MovieRandom";
import Login from "./Login";
import Movie from "./Movie";
import { BrowserRouter, Route, Link } from "react-router-dom";
import { LinkContainer } from "react-router-bootstrap";
function App() {
  const [activeTab, setActiveTab] = useState("");

  return (
    <>
      <Navbar collapseOnSelect expand="md" bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">OurMDB</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <NavDropdown title={activeTab} id="tabs-dropdown">
              <LinkContainer to="/Search">
                <NavDropdown.Item active={activeTab === "Search"} onClick={() => setActiveTab("Search")}>Search for a Title</NavDropdown.Item>
              </LinkContainer>
              <LinkContainer to="/">
                <NavDropdown.Item active={activeTab === "All"} onClick={() => setActiveTab("All")}>All Titles</NavDropdown.Item>
              </LinkContainer>
              <LinkContainer to="/Best">
                <NavDropdown.Item active={activeTab === "Best"} onClick={() => setActiveTab("Best")}>Best Titles</NavDropdown.Item>
              </LinkContainer>
              <LinkContainer to="/Random">
                <NavDropdown.Item active={activeTab === "Random"} onClick={() => setActiveTab("Random")}>Random Title</NavDropdown.Item>
              </LinkContainer>
              </NavDropdown>
            </Nav>
            <p></p>
            <Nav>
              <Login />
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <div>
      </div>
    </>
  );
}
export default App;
