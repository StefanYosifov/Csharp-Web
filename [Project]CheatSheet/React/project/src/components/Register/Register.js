import React, { useState} from 'react';
import { Link,useNavigate } from 'react-router-dom';
import LoginPage from '../Login/Login';

function RegisterPage() {

    const navigate=useNavigate();
    const [email,setEmail]=useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [repeatPassword,repeatSetPassword]=useState('');

    const handleEmailChange=(event)=>{
        setEmail(event.target.value);
    };

    const handleUsernameChange = (event) => {
        setUsername(event.target.value);
    };

    const handlePasswordChange = (event) => {
        setPassword(event.target.value);
    };

    const handleRepeatPasswordChange = (event) => {
        repeatSetPassword(event.target.value);
    };

    

    const handleSubmit = (event) => {
        event.preventDefault();
        // handle login logic here
    };

    return (
        <div className="login-page">
            <div className='login-wrapper'>

                <div className='auth-title'>
                <span >Register</span>
                </div>
                <form onSubmit={handleSubmit} className='form-login'>
                <div className="form-group">
                        <label htmlFor="email" className='label-login'>Email</label>
                        <input className='input-login'
                            type="text"
                            id="email"
                            value={email}
                            onChange={handleEmailChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="username" className='label-login'>Username</label>
                        <input className='input-login'
                            type="text"
                            id="username"
                            value={username}
                            onChange={handleUsernameChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password" className='label-login'>Password</label>
                        <input className='input-login'
                            type="password"
                            id="password"
                            value={password}
                            onChange={handlePasswordChange}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="repeatPass" className='label-login'>Repeat Password</label>
                        <input className='input-login'
                            type="password"
                            id="repeatPass"
                            value={repeatPassword}
                            onChange={handleRepeatPasswordChange}
                        />
                    </div>
                    <button type="submit" className='button-login'>Login</button>
                </form>

                <span className='bottom-text'>Don't have an account? Create one {<Link>here</Link>}!</span>
            </div>
        </div>
    );
}

export default RegisterPage;
