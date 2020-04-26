import React from 'react'
import { Link } from 'react-router-dom'

const Sidebar: React.FC = () => (
    <nav className="col-md-2 d-none d-md-block bg-light sidebar">
        <div className="sidebar-sticky">
            <ul className="nav flex-column">
                <li className="nav-item">
                    <Link to="/products" className="nav-link">
                        Products
                    </Link>
                </li>
                <li className="nav-item">
                    <Link to="/categories" className="nav-link">
                        Categories
                    </Link>
                </li>
            </ul>
        </div >
    </nav >
)

export default Sidebar