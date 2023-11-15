import React, { useState } from 'react';
import AddQuote from './components/AddQuote';
import EditQuote from './components/EditQuote';
import QuoteList from './components/QuoteList';

import './App.css';

function App() {
  const [quoteToEdit, setQuoteToEdit] = useState(null);
  const [openAddQuote, setOpenAddQuote] = useState(false);
  const [openEditQuote, setOpenEditQuote] = useState(false);
  const [openAddTag, setOpenAddTag] = useState(false);

  const handleQuoteClick = (quote) => {
    setQuoteToEdit(quote);
    setOpenEditQuote(true);
    setOpenAddQuote(false);
    setOpenAddTag(false); // Close AddTag if it's open
  };

  const handleStartAdd = () => {
    setOpenAddQuote(true);
    setOpenEditQuote(false);
    setOpenAddTag(false); // Close AddTag if it's open
  };

  const handleStartEdit = () => {
    setOpenEditQuote(true);
    setOpenAddQuote(false);
    setOpenAddTag(false); // Close AddTag if it's open
  };

  const handleStartAddTag = () => {
    setOpenAddTag(true);
    setOpenAddQuote(false);
    setOpenEditQuote(false); // Close AddQuote and EditQuote if they're open
  };

  return (
    <div>
      <h1 className='mb-[150px]'>React SPA Client</h1>
      <section className='flex w-[1300px] h-[900px] mx-auto'>
        <div className='w-[60%]'>
          <QuoteList handleQuoteClick={handleQuoteClick} />
        </div>
        <div className='w-[40%]'>
          <div className='h-[50%]'>
            <div>
              <button onClick={handleStartAdd}>Start Add</button>
              <button onClick={handleStartEdit}>Start Edit</button>
              <button onClick={handleStartAddTag}>Add Tag</button>
            </div>
            {openAddQuote && <AddQuote />}
            {(openEditQuote && quoteToEdit) && <EditQuote QuoteToEdit={quoteToEdit} /> }
            {
              (openEditQuote && !quoteToEdit)&&
              <div>To Edit, select a Quote</div>
            }
            {openAddTag && <div>Add Tag Form Goes Here</div>}
          </div>
        </div>
      </section>
    </div>
  );
}

export default App;
