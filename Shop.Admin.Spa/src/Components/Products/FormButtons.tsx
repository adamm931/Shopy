import React from 'react'
import { Link } from 'react-router-dom'

export const ProductFormButtons: React.FC = () =>
    (
        <div className="col-md-6 row">
            <div className="col-md-6 mb-3">
                <button type="submit" className="btn btn-primary btn-lg btn-block">Save</button>
            </div>
            <div className="col-md-6 mb-3">
                <Link to="/products" className="btn btn-secondary btn-lg btn-block">Cancel</Link>
            </div>
        </div>
    )