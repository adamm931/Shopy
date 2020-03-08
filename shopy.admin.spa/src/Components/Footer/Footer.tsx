import React from 'react'

const Footer: React.FC = () => {

    let today = new Date();
    let date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();

    return (
        <footer className="footer">
            <div className="container">
                <span>Admin portal {date}</span>
            </div>
        </footer>
    )
}

export default Footer