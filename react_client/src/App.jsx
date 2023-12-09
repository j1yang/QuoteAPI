import React, { useState,useEffect } from 'react';
import AddQuote from './components/AddQuote';
import EditQuote from './components/EditQuote';
import QuoteList from './components/QuoteList';

import './App.css';
import HandleTag from './components/ManageTag';
import Signup from './components/Signup';
import Login from './components/Login';

function App() {
  const [quoteToEdit, setQuoteToEdit] = useState(null);
  const [openAddQuote, setOpenAddQuote] = useState(false);
  const [openEditQuote, setOpenEditQuote] = useState(false);
  const [openAddTag, setOpenAddTag] = useState(false);

  const [config, setConfig] = useState()

  const fetchConfig = async () => {
    const token = localStorage.getItem('token');
    if (!token) {
      console.error('Token not available. Please log in.');
      return null;
    }
  
    return {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`,
      },
    };
  };
  useEffect(() => {
    const initializeConfig = async () => {
      const fetchedConfig = await fetchConfig();
      setConfig(()=>fetchedConfig)
    };
  
    initializeConfig();
  }, []);
  
  const handleQuoteClick = (quote) => {
    setQuoteToEdit(quote);
  };

  const handleStartAdd = () => {
    setOpenAddQuote(true);
    setOpenEditQuote(false);
    setOpenAddTag(false); 
    setQuoteToEdit(null);
  };

  const handleStartEdit = () => {
    setOpenEditQuote(true);
    setOpenAddQuote(false);
    setOpenAddTag(false);
    setQuoteToEdit(null);
  };

  const handleStartAddTag = () => {
    setOpenAddTag(true);
    setOpenAddQuote(false);
    setOpenEditQuote(false); 
    setQuoteToEdit(null);
  };
  const handleLogout = () => {
    // Clear stored token and expiration time on logout
    localStorage.removeItem('token');
    localStorage.removeItem('expirationTime');
    setIsLoggedIn(false);
  };
  const handleLogin = (token) => {
    setUserToken(token);
    setLoggedIn(true);
  };
  const [displayLogin, setDisplayLogin] = useState(true);
  const [userToken, setUserToken] = useState(null);
  const [isLoggedIn, setLoggedIn] = useState(false); 

  return (
    <div>
      <h1 className='mb-[150px]'>React SPA Client</h1>
      {isLoggedIn ? ( 
        <section className='flex w-[1300px] h-[900px] mx-auto'>
        <div className='w-[60%]'>
          <QuoteList handleQuoteClick={handleQuoteClick} config={config}/>
        </div>
        <div className='w-[40%]'>
          <div className='h-[50%]'>
            <div>
              <button onClick={handleStartAdd}>Start Add</button>
              <button onClick={handleStartEdit}>Start Edit</button>
              <button onClick={handleStartAddTag}>Add Tag</button>
            </div>
            {openAddQuote && <AddQuote config={config}/>}
            {(openEditQuote&& quoteToEdit) && <EditQuote QuoteToEdit={quoteToEdit} config={config}/> }
            {
              (openEditQuote && !quoteToEdit)&&
              <div>To Edit, select a Quote</div>
            }
            {(openAddTag) && <HandleTag config={config}/>}
          </div>
        </div>
      </section>
      ) : (
        displayLogin ? 
        <Login handleLogin={handleLogin} setDisplayLogin={setDisplayLogin} /> 
        :
        <Signup handleLogin={handleLogin} setDisplayLogin={setDisplayLogin} /> 
      )}
    </div>
  );
}

export default App;
