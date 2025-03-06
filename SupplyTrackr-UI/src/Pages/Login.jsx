import React, { useState } from 'react';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import { FaGoogle, FaFacebook } from "react-icons/fa";
import '../assets/styles/LoginStyle.css';

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({ email: "", password: ""});

  const validate = () => {
    let valid = true;
    let newErrors = { email: "", password: ""};

    if(!email) {
      newErrors.email = "Email is required";
      valid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      newErrors.email = "Invalid Email address";
      valid = false;
    }
    if(!password) {
      newErrors.password = "Password required";
      valid = false;
    } else if (password.length < 8) {
      newErrors.password = "Password length should be atleast 8 characters";
      valid = false;
    }
    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if(validate()) {
      alert("Logged in Successfully!");
    } else {
      document.getElementById("email").reportValidity();
      document.getElementById("password").reportValidity();
    }
  };

  return (
    <div className="content">
      <div className="container">
        <div className="row">
          <div className="col-md-6">
            <img src={InventoryTracking} alt="Image" className="img-fluid" />
          </div>
          <div className="col-md-6 contents">
            <div className="row justify-content-center">
              <div className="col-md-8">
                <div className="mb-4">
                  <h3>Sign In</h3>
                  <p>random text random text random text random text random text random text random text random text random text random text </p>
                  <form onSubmit={handleSubmit}>
                    <div className={`form-group first ${email ? "field--not-empty" : ""}`}>
                      <label htmlFor="email">Email</label>
                      <input
                       type="email"
                       className="form-control"
                       id="email"
                       value={email}
                       onChange={(e) => {
                        setEmail(e.target.value);
                        e.target.setCustomValidity(""); // Clear previous error
                       }}
                       onInvalid={(e) => e.target.setCustomValidity(errors.email)}
                       required />
                      {errors.email && <p className="error-text">{errors.email}</p>}
                    </div>
                    <div className={`form-group last mb-4 ${password ? "field--not-empty" : ""}`}>
                      <label htmlFor="password">Password</label>
                      <input
                       type="password"
                       className="form-control"
                       id="password"
                       value={password}
                       onChange={(e) => {
                        setPassword(e.target.value);
                        e.target.setCustomValidity(""); // Clear previous error
                       }}
                       onInvalid={(e) => e.target.setCustomValidity(errors.password)}
                       required />
                      {/* {errors.password && <p className="error-text">{errors.password}</p>} */}
                    </div>
                    <div className="d-flex mb-5 align-items-center">
                      <label className="control control--checkbox mb-0">
                        <span className="caption">Remember me</span>
                        <input type="checkbox" defaultChecked />
                        <div className="control__indicator"></div>
                      </label>
                    <span className="ml-auto">
                      <a href="#" className="forget-pass">Forgot Password</a>
                    </span>
                    </div>
                    <button type="submit" className="btn btn-block btn-primary">Log In</button>
                    <span className="d-block text-left my-4 text-muted">- or Log in with -</span>
                    <div className="social-login">
                      <a href="" className="google">
                        <span className="icon-google mr-3">
                          <FaGoogle className='icon' />
                        </span>
                      </a>
                      <a href="" className="facebook">
                        <span className="icon-facebook mr-3">
                          <FaFacebook className='icon' />
                        </span>
                      </a>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Login
