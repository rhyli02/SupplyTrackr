import React, { useState } from 'react';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
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
                  <p className='mb-4'>random text random text random text random text random text random text random text random text random text random text </p>
                </div>
                <form onSubmit={handleSubmit}>
                  <div className={`form-group first mb-1 ${email ? "field--not-empty" : ""}`}>
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
                    {errors.password && <p className="error-text">{errors.password}</p>}
                  </div>
                  <div className="d-flex mb-5 justify-content-between">
                    <label className="control control--checkbox mb-0">
                      <span className="caption">Remember me</span>
                      <input type="checkbox" defaultChecked />
                      <div className="control__indicator"></div>
                    </label>
                    <span className="ml-auto">
                      <a href="#" className="forget-pass">Forgot Password</a>
                    </span>
                  </div>
                  <div className="text-center">
                    <button type="submit" className="btn btn-block btn-primary ">Log In</button>
                    <span className="d-block text-center my-2">No Account yet? <a href="">Sign Up</a></span>
                    <span className="d-block text-center my-4 text-muted">- or Log in with -</span>
                    <div className="social-login d-flex justify-content-center">
                      <a href="" className="google m-1">
                        <span className="icon-google">
                        </span>
                      </a>
                      <a href="" className="facebook m-1">
                        <span className="icon-facebook">
                        </span>
                      </a>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Login
