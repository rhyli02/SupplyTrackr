import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import '../assets/styles/style.css';

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
    const form = e.currentTarget;
    if (form.checkValidity() === false){
      e.stopPropagation();
    } else {
      alert("Registration Successful!");
    }
    setValidated(true);
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
                <form className={`form-floating needs-validation ${ validated ? "was-validated" : ""}`} noValidate onSubmit={handleSubmit}>
                  <div className='form-floating first mb-1'>
                    <input
                      type='text'
                      name='firstName'
                      className='form-control'
                      id='firstName'
                      placeholder='Firstname'
                      value={formData.firstName}
                      onChange={handleChange}
                      pattern='[A-Za-z/s]+'
                      required
                    />
                    <label htmlFor="firstName">Firstname</label>
                    <div className="valid-feedback">
                      Looks Good!
                    </div>
                    <div className="invalid-feedback">
                      Enter your Firstname.
                    </div>
                  </div>
                  <div className='form-floating mid mb-1'>
                    <input
                      type='text'
                      name='lastName'
                      className='form-control'
                      id='lastName'
                      placeholder='Lastname'
                      value={formData.lastName}
                      onChange={handleChange}
                      pattern='[A-Za-z/s]+'
                      required />
                      <label htmlFor="lastName">Lastname</label>
                      <div className="valid-feedback">
                      Looks Good!
                      </div>
                      <div className="invalid-feedback">
                        Enter your Lastname.
                      </div>
                  </div>
                  <div className='form-floating mid mb-1'>
                    <input
                      type='email'
                      name='email'
                      className='form-control'
                      id='email'
                      placeholder='name@example.com'
                      value={formData.email}
                      onChange={handleChange}
                      required />
                      <label htmlFor="email">Email</label>
                      <div className="valid-feedback">
                        Looks Good!
                      </div>
                      <div className="invalid-feedback">
                        Please enter a valid email.
                      </div>
                  </div>
                  <div className='form-floating mid mb-1'>
                    <input
                      type='password'
                      name='password'
                      className='form-control'
                      id='password'
                      placeholder='Password'
                      value={formData.password}
                      onChange={handleChange}
                      pattern='(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}'
                      required />
                      <label htmlFor="password">Password</label>
                      <div className="valid-feedback">
                        Looks Good!
                      </div>
                      <div className="invalid-feedback">
                        Your password must have the following:
                        <ul className="mb-0">
                          <li>atleast 8 characters</li>
                          <li>One uppercase letter</li>
                          <li>One lowercase letter</li>
                          <li>One number</li>
                          <li>One special character</li>
                        </ul>
                      </div>
                  </div>
                  <div className='form-floating last mb-5'>
                    <input
                      type='password'
                      name='confirmPassword'
                      className='form-control'
                      id='confirmPassword'
                      placeholder='Confirm Password'
                      value={formData.confirmPassword}
                      onChange={handleChange}
                      required />
                      <label htmlFor="confirmPassword">Confirm Password</label>
                      <div className="valid-feedback">
                        Looks Good!
                      </div>
                      <div className="invalid-feedback">
                        Password doesn't match.
                      </div>
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
