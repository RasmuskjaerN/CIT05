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
function App() {
  const [activeTab, setActiveTab] = useState("All");

  return (
    <>
      <Navbar collapseOnSelect expand="md" bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">OurMDB</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <NavDropdown title={activeTab} id="tabs-dropdown">
                <NavDropdown.Item
                  href="#All"
                  active={activeTab === "All"}
                  onClick={() => setActiveTab("All")}
                >
                  All Titles
                </NavDropdown.Item>
                <NavDropdown.Item
                  href="#Best"
                  active={activeTab === "Best"}
                  onClick={() => setActiveTab("Best")}
                >
                  Best Titles
                </NavDropdown.Item>
                <NavDropdown.Item
                  href="#Random"
                  active={activeTab === "Random"}
                  onClick={() => setActiveTab("Random")}
                >
                  Random Title
                </NavDropdown.Item>
              </NavDropdown>
              <FormControl
                type="text"
                placeholder="Search"
                className="mr-sm-2"
                size="lg"
              />
            </Nav>
            <p></p>
            <Nav>
              <Login />
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <div>
        {activeTab === "All" && <Pagin />}
        {activeTab === "Best" && <MovieBest />}
        {activeTab === "Random" && <MovieRandom />}
      </div>
    </>
  );
}
export default App;
