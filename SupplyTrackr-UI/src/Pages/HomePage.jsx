import '../assets/styles/style.css'
import React from 'react'
import { Link } from 'react-router-dom'

const HomePage = () => {
  return (
    <div className="wrapper">
      <div className="navbar-custom">
        <div className="topbar container-fluid">
          <div className="d-flex align-items-center gap-lg-2 gap-1">
            <div className="logo-topbar">
              <Link className="logo-light">wLogo</Link>
              <Link className="logo-dark">dLogo</Link>
            </div>
            <button className="button-toggle-menu">
              <i className="icon-menu"></i>
            </button>
            <button className="navbar-toggle" data-bs-toggle='collapse' data-bs-target='#topnav-menu-content'>
              <div className="lines">
                <span></span>
                <span></span>
                <span></span>
              </div>
            </button>
            <div className="app-search dropdown d-none d-lg-block">
              <form>
                <div className="input-group">
                  <input type="search"id="top-search" className="form-control" placeholder="Search..." />
                  <span className="icon-search"></span>
                  <button type="submit" className="input-group-text btn btn-primary">Search</button>
                </div>
              </form>
              <div className="dropdown-menu dropdown-menu-animated dropdown-lg" id="search-dropdown">
                <div className="dropdown-header noti-title">
                  <h5 className="text-overflow mb-2">
                    "Found "
                    <span className="text-danger">17</span>
                    " Results"
                  </h5>
                </div>
                <a href="" className="dropdown-item notify-item">
                  <i className="icon-file-text"></i>
                  <span>Analytics Report</span>
                </a>
                <a href="" className="dropdown-item notify-item">
                  <i className="icon-lifebuoy"></i>
                  <span>How can I help?</span>
                </a>
                <a href="" className="dropdown-item notify-item">
                  <i className="icon-cog"></i>
                  <span>User Profile Settings</span>
                </a>
              </div>
            </div>
          </div>
          <ul className="topbar-menu d-flex align-items-center gap-3">
            <li className='dropdown d-lg-none'></li>
            <li className='dropdown'></li>
            <li className='dropdown notification-list'></li>
            <li className='dropdown d-none d-sm-inline-block'></li>
            <li className='d-none d-sm-inline-block'></li>
            <li className='d-none d-sm-inline-block'></li>
            <li className='d-none d-sm-inline-block'></li>
            <li className='dropdown'></li>
          </ul>
        </div>
        navbar
      </div>
      <div className="leftside-menu menu-item-active">
        leftside menu
      </div>
      <div className="content-page">
        content
      </div>
    </div>
  )
}

export default HomePage
