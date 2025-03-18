import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import '../node_modules/bootstrap/dist/css/bootstrap-grid.min.css'
import "bootstrap-icons/font/bootstrap-icons.css";
import Login from './Pages/Login'
import ForgotPassword from './Pages/ForgotPassword'
import SignUp from './Pages/SignUp'

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Login />}/>
        <Route path='/forgot-password' element={<ForgotPassword />}/>
        <Route path='/sign-up' element={<SignUp />}/>
      </Routes>
    </Router>
  )
}
export default App
