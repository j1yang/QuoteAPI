import React, { useState, useEffect } from 'react';
import axios from 'axios';

const AddQuote = () => {
  const [newQuote, setNewQuote] = useState({ Text: '', Author: '', Tag: '' });
  const [allTags, setAllTags] = useState([]);
  useEffect(() => {
    // Fetch all tags from the API
    axios.get('https://localhost:7082/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }, []);

  const handleTagChange = (selectedTags) => {
    setNewQuote({ ...newQuote, Tag: selectedTags[0] });
  };

  const addQuote = () => {
    // Make a POST request to add a new quote
    axios.post('https://localhost:7082/addNewQuote', newQuote, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then(response => console.log('Quote added successfully:', response.data))
      .catch(error => console.error('Error adding quote:', error));
  };

  return (
    <div className="bg-gray p-8 rounded shadow mb-4">
      <h2 className="text-2xl font-bold mb-4">Add New Quote</h2>
      <div className="mb-4">
        <label className="block text-white-800 text-sm font-semibold mb-2" htmlFor="quoteText">Quote Text</label>
        <input
          type="text"
          id="quoteText"
          className="w-full border rounded py-2 px-3 text-white-700 leading-tight focus:outline-none focus:shadow-outline"
          placeholder="Enter the quote text"
          value={newQuote.text}
          onChange={(e) => setNewQuote({ ...newQuote, Text: e.target.value })}
        />
      </div>
      <div className="mb-4">
        <label className="block text-white-800 text-sm font-semibold mb-2" htmlFor="quoteAuthor">Author</label>
        <input
          type="text"
          id="quoteAuthor"
          className="w-full border rounded py-2 px-3 text-white-700 leading-tight focus:outline-none focus:shadow-outline"
          placeholder="Enter the author's name"
          value={newQuote.author}
          onChange={(e) => setNewQuote({ ...newQuote, Author: e.target.value })}
        />
      </div>
      <div className="mb-4">
        <label className="block text-white-800 text-sm font-semibold mb-2">Tags</label>
        <select
          multiple
          className="w-full border rounded py-2 px-3 text-white-700 leading-tight focus:outline-none focus:shadow-outline"
          onChange={(e) => handleTagChange(Array.from(e.target.selectedOptions, (option) => option.value))}
        >
          {allTags.map(tag => (
            <option key={tag.id} value={tag.name}>{tag.name}</option>
          ))}
        </select>
      </div>
      <button
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
        onClick={addQuote}
      >
        Add Quote
      </button>
    </div>
  );
};

export default AddQuote;
