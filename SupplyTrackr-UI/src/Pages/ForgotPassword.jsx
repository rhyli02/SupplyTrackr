import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import '../assets/styles/LoginStyle.css';

const Login = () => {
  const [email, setEmail] = useState("");
  const [errors, setErrors] = useState({ email: "", password: ""});

  const validate = () => {
    let valid = true;
    let newErrors = { email: ""};

    if(!email) {
      newErrors.email = "Email is required";
      valid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      newErrors.email = "Invalid Email address";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if(validate()) {
      alert("An email has been set to your email address.");
    } else {
      document.getElementById("email").reportValidity();
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
                  <h3>Forgot Password</h3>
                  <p className='mb-4'>Enter your Email address to reset your password.</p>
                </div>
                <form onSubmit={handleSubmit}>
                  <div className={`form-group single mb-5 ${email ? "field--not-empty" : ""}`}>
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
                  <div className="text-center">
                    <button type="submit" className="btn btn-block btn-primary ">Submit</button>
                    <span className="d-block text-center my-2"><Link to='/'>Return to Login</Link></span>
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
