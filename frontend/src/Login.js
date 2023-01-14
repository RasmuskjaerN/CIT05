import { useState, useEffect } from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
import useLocalStorage from "./useLocalStorage";
import useInput from "./useInput";

const Login = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const from = location.state?.from?.pathname || "/";
  const [username, resetUser, userAttri] = useInput("user", "");
  const [password, resetPwd, pwdAttri] = useInput("password", "");
  const [userId, setUid] = useState("");
  const [token, setToken] = useLocalStorage("token", "");

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
    } catch {}
  };

  return (
    <section>
      <p></p>
      <h1>Sign In</h1>
      <form onSubmit={handleSubmit}>
        <label>Username:</label>
        <input type="text" id="username" {...userAttri} />

        <label>Password:</label>
        <input type="password" id="password" {...pwdAttri} />
        <button>Sign In</button>
      </form>
      <p>
        Need an Account?
        <br />
        <span className="line">
          <Link to="/register">Sign Up</Link>
        </span>
      </p>
    </section>
  );
};

export default Login;
