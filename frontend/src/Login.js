import useLocalStorage from "./useLocalStorage";
import useInput from "./useInput";
import { Col, Container, Row } from "react-bootstrap";
import { useState } from "react";

const Login = () => {
  const [username, setUser, userAttri] = useInput("user", "");
  const [password, resetPwd, pwdAttri] = useInput("password", "");
  const [userId, setUid] = useLocalStorage("uid","");
  const [token, setToken] = useLocalStorage("token", "");
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const loginData = {
      UserName: username,
      Password: password,
    };

    const options = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loginData),
    };
    try {
      const response = await fetch(
        "http://localhost:5001/api/user/login",
        options
      );
      const json = await response.json();
      setUid(json.uid);
      setToken(json.token);

      console.log(JSON.stringify(json));
      console.log(token);
      console.log(userId);
      // setUser(json.username);
      // setPwd(json.password);
      //resetUser();
      //if (token != "undefined") navigate(from, { replace: true });
    } catch(error) {
      setError(error.message + "Invalid Login")
      console.log(error)
    }
  };

  return (
    <Container>
      <form onSubmit={handleSubmit}>
      <Row>
          <Col xs={6}>
            <div class="input-group">
              <input
                class="form-control"
                type="text"
                id="username"
                placeholder=""
                {...userAttri}
              />
            </div>
            <div>
              <input
                class="form-control"
                type="password"
                id="password"
                placeholder=""
                {...pwdAttri}
              />
            </div>
          </Col>
          <Col xs={6}>
          <button type="submit" class="btn btn-primary">
            Login
          </button>
          <button type="submit" class="btn btn-primary">
            Register
          </button>
          </Col>
        </Row>
      </form>
    </Container>
  );
}

export default Login;
