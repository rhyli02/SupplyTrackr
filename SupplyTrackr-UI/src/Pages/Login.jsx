import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { api } from '../assets/js/api';
import InventoryTracking from "../assets/images/Inventory-Tracking.png";
import '../assets/styles/style.css';

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [validated, setValidated] = useState(false);
  const [rememberMe, setRememberMe] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7178/api/Profiles")
      .then((res) => res.json())
      .then((data) => {
        console.log("Profiles: ", data);
      })
      .catch((err) => {
        console.log("API Error: ", err)
      });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    const form = e.currentTarget;
    if(form.checkValidity() === false) {
      e.stopPropagation();
    } else {
      alert("Logged in Successfully!");
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
                  <h3>Login</h3>
                  <p className='mb-4'>Your all-in-one solution for supply tracking and inventory management. Log in to stay on top of your operations. </p>
                </div>
                {/* ------ form ------ */}
                <form onSubmit={handleSubmit} className={`form-floating needs-validation ${ validated ? "was-validated" : ""}`} noValidate>
                  <div className='form-floating mb-3'>
                    <input
                      type="email"
                      className="form-control"
                      id="email"
                      placeholder='name@example.com'
                      value={email}
                      onChange={(e) => {
                      setEmail(e.target.value);
                      }}
                      required />
                      <label htmlFor="email" className='form-label'>Email</label>
                      <div className="invalid-feedback">
                        Incorrect Email
                      </div>
                  </div>
                  <div className='form-floating mb-4'>
                    <input
                      type="password"
                      className="form-control"
                      id="password"
                      placeholder='Password'
                      value={password}
                      onChange={(e) => {
                      setPassword(e.target.value);
                      }}
                      required />
                      <div className="invalid-feedback">
                        Incorrect Password
                      </div>
                      <label htmlFor="password" className='form-label'>Password</label>
                  </div>
                  <div className="d-flex mb-5 justify-content-between">
                    <div className="form-check form-check-inline">
                      <input
                        type="checkbox"
                        id="rememberCb"
                        className="form-check-input"
                        checked={rememberMe}
                        onChange={(e) => setRememberMe(e.target.checked)}/>
                      <label htmlFor="rememberCb" className="form-check-label">Remember me</label>
                    </div>
                    <span className="ml-auto">
                      <Link to='/forgot-password' className='forgot-pass'>Forgot Password</Link>
                    </span>
                  </div>
                  <div className="text-center">
                    <button type="submit" className="btn btn-primary mb-4">Log In</button>
                    <span className="d-block text-center">No Account yet?</span>
                    <h3><Link to='/sign-up'>Sign up</Link></h3>
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
                {/* ------ form ------ */}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Login
