import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import '../assets/styles/style.css';

const ForgotPassword = () => {
  const [email, setEmail] = useState("");
  const [validated, setValidated] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    const form = e.currentTarget;
    if(form.checkValidity() === false) {
      e.stopPropagation();
    } else {
      alert("An email has been set to your email address.");
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
                  <h3>Forgot Password</h3>
                  <p className='mb-4'>Enter your Email address to reset your password.</p>
                </div>
                <form onSubmit={handleSubmit} className={`form-floating needs-validation ${ validated ? "was-validated" : ""}`} noValidate>
                  <div className='form-floating mb-4'>
                    <input
                      type="email"
                      className="form-control"
                      id="email"
                      placeholder="name@example.com"
                      value={email}
                      onChange={(e) => {
                      setEmail(e.target.value);
                      }}
                      required />
                      <label htmlFor="email">Email</label>
                      <div className="invalid-feedback">
                        Invalid Email
                      </div>
                  </div>
                  <div className="text-center">
                    <button type="submit" className="btn btn-primary ">Submit</button>
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

export default ForgotPassword
