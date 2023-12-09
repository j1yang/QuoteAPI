import React, { useState } from 'react';
import axios from 'axios';

const Signup = ({setDisplayLogin}) => {
  const [userData, setUserData] = useState({
    FirstName: '',
    LastName: '',
    Email: '',
    PhoneNumber: '',
    Roles: ['User'],
    UserName: '',
    Password: '',
  });

  const [errorMessage, setErrorMessage] = useState([]);
  const [successMessage, setSuccessMessage] = useState(null);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUserData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSignup = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:7082/api/register', userData);
      console.log('User registered successfully:', response.data);
      setSuccessMessage('Registration successful! Please Signin your account...');
      setErrorMessage([])
    } catch (error) {
      const errorMessages = Object.values(error.response.data).flat();
      setErrorMessage(errorMessages);
      setSuccessMessage(null);

            console.error('Registration failed:', error.response.data);
    }
  };

  return (
    <div className="max-w-md mx-auto mt-10 p-6 rounded-md shadow-md">
      <h2 className="text-2xl font-semibold mb-6">Signup Page</h2>
      <form onSubmit={handleSignup}>
        <label className="block mb-4">
          First Name:
          <input
            type="text"
            name="FirstName"
            value={userData.FirstName}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Last Name:
          <input
            type="text"
            name="LastName"
            value={userData.LastName}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Email:
          <input
            type="email"
            name="Email"
            value={userData.Email}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Phone Number:
          <input
            type="tel"
            name="PhoneNumber"
            value={userData.PhoneNumber}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Username:
          <input
            type="text"
            name="UserName"
            value={userData.UserName}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <label className="block mb-4">
          Password:
          <input
            type="password"
            name="Password"
            value={userData.Password}
            onChange={handleInputChange}
            className="form-input mt-1 block w-full bg-gray-200 dark:bg-white-900"
          />
        </label>
        <button type="submit" className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-700">
          Signup
        </button>
      </form>
        {errorMessage && (
          errorMessage.map(e => (
            <div key={e} className="mt-4 p-3 bg-red-200 text-red-800 rounded-md">
              <p>{e}</p>
            </div>
          ))
        )}
        {successMessage && (
          <div className="mt-4 p-3 bg-green-200 text-green-800 rounded-md">
            <p>{successMessage}</p>
          </div>
        )}
        <p className="mt-4 text-gray-600">
          Already have an account? <div onClick={() => setDisplayLogin(true)} className="text-blue-500 cursor-pointer">Login here</div>.
        </p>
    </div>
  );
};

export default Signup;
