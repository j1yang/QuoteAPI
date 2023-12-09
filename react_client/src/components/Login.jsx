import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Login = ({ handleLogin, setDisplayLogin }) => {
  const [loginData, setLoginData] = useState({
    UserName: '',
    Password: '',
  });

  const [errorMessage, setErrorMessage] = useState(null);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setLoginData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleLoginSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:7082/api/login', loginData);
      console.log('Login successful:', response.data);
      setErrorMessage(null);

      // Store token and expiration time in localStorage
      const expirationTime = new Date().getTime() + 50 * 60 * 1000; // 50 minutes
      localStorage.setItem('token', response.data.token);
      localStorage.setItem('expirationTime', expirationTime);

      handleLogin(response.data.token); // Pass the token to the parent component
    } catch (error) {
      setErrorMessage('Invalid username or password.');
      console.error('Login failed:', error.response.data);
    }
  };

  useEffect(() => {
    // Check if there's a valid session on component mount
    const token = localStorage.getItem('token');
    const expirationTime = localStorage.getItem('expirationTime');

    if (token && expirationTime && new Date().getTime() < parseInt(expirationTime, 10)) {
      handleLogin(token);
    }
  }, []); // Empty dependency array to run the effect only once on component mount

  return (
    <div className="max-w-md mx-auto mt-10 p-6 rounded-md shadow-md">
      <h2 className="text-2xl font-semibold mb-6">Login Page</h2>
      <form onSubmit={handleLoginSubmit}>
        <label className="block mb-4">
          Username:
          <input
            type="text"
            name="UserName"
            value={loginData.UserName}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Password:
          <input
            type="password"
            name="Password"
            value={loginData.Password}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <button type="submit" className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-700">
          Login
        </button>
      </form>
      {errorMessage && (
        <div className="mt-4 p-3 bg-red-200 text-red-800 rounded-md">
          <p>{errorMessage}</p>
        </div>
      )}
      <p className="mt-4 text-gray-600">
        Don't have an account? <div onClick={() => setDisplayLogin(false)} className="text-blue-500 cursor-pointer">Signup here</div>.
      </p>
    </div>
  );
};

export default Login;

