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
              <a href="" className="logo-light"></a>
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

                <div className="dropdown-header noti-title">
                  <h6 className="text-overflow mb-2 text-uppercase">Users</h6>
                </div>

                <div className="notification-list">
                  <a href="" className="dropdown-item notify-itm">
                    <img src="" alt="" />
                    <div className="w-100">
                      <h5 className="m-0 font-14">Name</h5>
                      <span className="font-12 mb-0">Position</span>
                    </div>
                  </a>
                </div>
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
      </div>

      <div className="leftside-menu menuitem-active">

        <a href="" className="logo logo-light">
          logo
        </a>

        <div className="button-sm-hover" data-bs-toggle="tooltip" data-bs-placement="right" title="Show Full Sidebar">
          <i className="ri-checkbox-blank-circle-line align-middle"></i>
        </div>

        <div className="button-close-fullside-bar">
          <i className="ri-close-fill align-middle"></i>
        </div>

        <div className="h-100" id="leftside-menu-container" data-simplebar>

          <div className="leftbar-user">
            <a href="#">

              {/* img user picture */}

              {/* span user's name */}

            </a>
          </div>

          <div className="side-nav">

            <li className="side-nav-title">Navigation</li>
          </div>
        </div>

      </div>
      <div className="content-page">
        content here!!!
      </div>
    </div>
  )
}

export default HomePage
