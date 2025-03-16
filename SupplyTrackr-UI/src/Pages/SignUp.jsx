import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import '../assets/styles/LoginStyle.css';

const SignUp = () => {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [errors, setErrors] = useState({});

  const validate = () => {
    let valid = true;
    let newErrors = {};

    if(!formData.firstName.trim()) {
      newErrors.firstName = "field is required";
      valid = false;
    } else if (!formData.lastName.trim()) {
      newErrors.lastName = "field is required";
      valid = false;
    } else if (!formData.email.trim()) {
      newErrors.email = "email is required"
      valid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      newErrors.email = "Invalid Email address";
      valid = false;
    } else if (!formData.password.trim()) {
      newErrors.password = "password is required";
      valid = false;
    } else if (formData.password.length < 8) {
      newErrors.password = "password must be at least 8 characters";
      valid = false;
    } else if (!formData.confirmPassword.trim()) {
      newErrors.confirmPassword = "confirm password is required";
      valid = false;
    } else if (formData.password !== formData.confirmPassword) {
      newErrors.confirmPassword = "passwords do not match";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if(validate()) {
      alert("Sign Up success!");
      console.log("Form Data: ", formData);
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
                  <h3>Register</h3>
                  <p className='mb-4'>Create a new account here.</p>
                </div>
                <form onSubmit={handleSubmit}>
                  <div className={`form-group first mb-1 ${formData.firstName ? "field--not-empty" : ""}`}>
                    <label htmlFor="firstName">Firstname</label>
                    <input
                      type="text"
                      className="form-control"
                      id="firstName"
                      value={formData.firstName}
                      onChange={(e) => {
                      setFormData({...formData, firstName: e.target.value});
                      e.target.setCustomValidity(""); // Clear previous error
                      }}
                      onInvalid={(e) => e.target.setCustomValidity(errors.firstName)}
                      required />
                    {errors.firstName && <p className="error-text">{errors.firstName}</p>}
                  </div>
                  <div className={`form-group mid mb-1 ${formData.lastName ? "field--not-empty" : ""}`}>
                    <label htmlFor="lastName">Lastname</label>
                    <input
                      type="text"
                      className="form-control"
                      id="lastName"
                      value={formData.lastName}
                      onChange={(e) => {
                      setFormData({...formData, lastName: e.target.value})
                      e.target.setCustomValidity(""); // Clear previous error
                      }}
                      onInvalid={(e) => e.target.setCustomValidity(errors.lastName)}
                      required />
                    {errors.lastName && <p className="error-text">{errors.lastName}</p>}
                  </div>
                  <div className={`form-group mid mb-1 ${formData.email ? "field--not-empty" : ""}`}>
                    <label htmlFor="email">Email</label>
                    <input
                      type="email"
                      className="form-control"
                      id="email"
                      value={formData.email}
                      onChange={(e) => {
                      setFormData({...formData, email: e.target.value})
                      e.target.setCustomValidity(""); // Clear previous error
                      }}
                      onInvalid={(e) => e.target.setCustomValidity(errors.email)}
                      required />
                    {errors.email && <p className="error-text">{errors.email}</p>}
                  </div>
                  <div className={`form-group mid mb-1 ${formData.password ? "field--not-empty" : ""}`}>
                    <label htmlFor="password">Password</label>
                    <input
                      type="password"
                      className="form-control"
                      id="password"
                      value={formData.password}
                      onChange={(e) => {
                      setFormData({...formData, password: e.target.value})
                      e.target.setCustomValidity(""); // Clear previous error
                      }}
                      onInvalid={(e) => e.target.setCustomValidity(errors.password)}
                      required />
                    {errors.password && <p className="error-text">{errors.password}</p>}
                  </div>
                  <div className={`form-group last mb-5 ${formData.confirmPassword ? "field--not-empty" : ""}`}>
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input
                      type="password"
                      className="form-control"
                      id="confirmPassword"
                      value={formData.confirmPassword}
                      onChange={(e) => {
                      setFormData({...formData, confirmPassword: e.target.value})
                      e.target.setCustomValidity(""); // Clear previous error
                      }}
                      onInvalid={(e) => e.target.setCustomValidity(errors.confirmPassword)}
                      required />
                    {errors.confirmPassword && <p className="error-text">{errors.confirmPassword}</p>}
                  </div>
                  <div className="text-center">
                    <button type="submit" className="btn btn-block btn-primary ">Register</button>
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

export default SignUp
