import '../assets/styles/style.css'
import React from 'react'

const HomePage = () => {
  return (
    <div className="wrapper">
      <div className="navbar-custom">
        <div className="topbar container-fluid">
          <div className="d-flex align-items-center gap-lg-2 gap-1">
            <div className="logo"></div>
            <button className="button-toggle-menu">

            </button>
            <button className="navbar-toggle" data-bs-toggle='collapse' data-bs-target='#topnav-menu-content'>

            </button>
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
