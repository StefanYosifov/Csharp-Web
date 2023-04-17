import React, { useState } from 'react';
import RegisterPage from '../Register/Register';
import { Link, Navigate, Router, useNavigate } from 'react-router-dom';
import { login } from '../../api/requests';

export function LoginPage() {

    const navigate=useNavigate();

    const [formData, setFormData] = useState({
        userName: "",
        password: "",
    });


    const handleSubmit = (event) => {
        event.preventDefault();
        login(formData.userName, formData.password);
        navigate('/');
    }

   

    const handleChange = (event) => {
        const newData = { ...formData };
        console.log(event.target);
        newData[event.target.id] = event.target.value;
        setFormData(newData);
    };

    return (
        <div className="login-page">
            <div className='login-wrapper'>

                <h1>Login</h1>
                <form onSubmit={handleSubmit} className='form-login'>
                    <div className="form-group">
                        <label htmlFor="userName" className='label-login'>Username</label>
                        <input className='input-login'
                            type="text"
                            id="userName"
                            value={formData.userName}
                            onChange={handleChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password" className='label-login'>Password</label>
                        <input className='input-login'
                            type="password"
                            id="password"
                            value={formData.password}
                            onChange={handleChange}
                        />
                    </div>
                    <button type="submit" className='button-login'>Login</button>
                </form>
                <span className='bottom-text'>Already have an account? Log in here {<Link>here</Link>}!</span>
            </div>
        </div>
    );
}

export default LoginPage;
