import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
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

  const navigate = useNavigate();
  const [validated, setValidated] = useState(false);
  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setFormData({...formData, [e.target.name]: e.target.value})
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    let newErrors = {};

    if (!formData.firstName.trim()) {
      newErrors.firstName = "Please enter your first name.";
    }
    if (!formData.lastName.trim()) {
      newErrors.lastName = "Please enter your last name.";
    }
    if (!formData.email.trim()) {
      newErrors.email = "Please enter a valid email address.";
    }
    if (!formData.password.match(/(?=.*[A-Z])(?=.*\d).{8,}/)) {
      newErrors.password = "Password must be at least 8 characters, include one uppercase letter, and a number.";
    }
    if (formData.password !== formData.confirmPassword) {
      newErrors.confirmPassword = "Passwords do not match.";
    }

    setErrors(newErrors);

    if (Object.keys(newErrors).length === 0) {
      alert("Registration Successful!");
      navigate("/");
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
                <form className={`needs-validation ${ validated ? "was-validated" : ""}`} noValidate onSubmit={handleSubmit}>
                  <div className={`form-group first mb-1 justify-content-between ${formData.firstName ? "field--not-empty" : ""} ${errors.firstName ? "is-invalid border border-danger" : ""}`}>
                    <label htmlFor="firstName" className='form-label'>Firstname</label>
                    <input
                      type='text'
                      name='firstName'
                      className='form-control'
                      id='firstName'
                      value={formData.firstName}
                      onChange={handleChange}
                      pattern='[A-Za-z/s]+'
                      required
                    />
                    {errors.firstName && (
                      <span className="text-danger mt-1" data-bs-toggle="tooltip" data-bs-placement="top" title={errors.firstName}>
                        <i className="bi bi-exclamation-circle"></i>
                      </span>
                    )}
                  </div>
                  <div className={`form-group mid mb-1 justify-content-between ${formData.lastName ? "field--not-empty" : ""} ${errors.lastName ? "is-valid border border-danger" : ""}`}>
                    <label htmlFor="lastName" className='form-label'>Lastname</label>
                    <input
                      type='text'
                      name='lastName'
                      className='form-control'
                      id='lastName'
                      value={formData.lastName}
                      onChange={handleChange}
                      pattern='[A-Za-z/s]+'
                      required />
                      {errors.lastName && (
                      <span className="text-danger mt-1" data-bs-toggle="tooltip" data-bs-placement="top" title={errors.lastName}>
                        <i className="bi bi-exclamation-circle"></i>
                      </span>
                      )}
                  </div>
                  <div className={`form-group mid mb-1 justify-content-between ${formData.email ? "field--not-empty" : ""} ${errors.email ? "is-valid border border-danger" : ""}`}>
                    <label htmlFor="email">Email</label>
                    <input
                      type='email'
                      name='email'
                      className='form-control'
                      id='email'
                      value={formData.email}
                      onChange={handleChange}
                      required />
                      {errors.email && (
                      <span className="text-danger mt-1" data-bs-toggle="tooltip" data-bs-placement="top" title={errors.email}>
                        <i className="bi bi-exclamation-circle"></i>
                      </span>
                      )}
                  </div>
                  <div className={`form-group mid mb-1 justify-content-between ${formData.password ? "field--not-empty" : ""} ${errors.password ? "is-valid border border-danger" : ""}`}>
                    <label htmlFor="password">Password</label>
                    <input
                      type='password'
                      name='password'
                      className='form-control'
                      id='password'
                      value={formData.password}
                      onChange={handleChange}
                      pattern='(?=.*[A-Z])(?=.*\d).{8,}'
                      required />
                      {errors.password && (
                        <span className='text-danger mt-1' data-bs-toggle='tooltip' data-bs-placement='top' title={errors.password}>
                          <i className='bi bi-exclamation-circle'></i>
                        </span>
                      )}
                  </div>
                  <div className={`form-group last mb-5 justify-content-between ${formData.confirmPassword ? "field--not-empty" : ""} ${errors.confirmPassword ? "is-valid border border-danger" : ""}`}>
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input
                      type='password'
                      name='confirmPassword'
                      className='form-control'
                      id='confirmPassword'
                      value={formData.confirmPassword}
                      onChange={handleChange}
                      required />
                      {errors.confirmPassword && (
                        <span className='text-danger mt-1' data-bs-toggle='tooltip' data-bs-placement='top' title={errors.confirmPassword}>
                          <i className='bi bi-exclamation-circle'></i>
                        </span>
                      )}
                  </div>
                  <div className="text-center">
                    <button type="submit" className="btn btn-block btn-primary">Register</button>
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
