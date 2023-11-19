import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Autosuggest from 'react-autosuggest';

const AddQuote = () => {
  const [newQuote, setNewQuote] = useState({ Text: '', Author: '', Tags: [] });
  const [allTags, setAllTags] = useState([]);
  const [suggestions, setSuggestions] = useState([]);
  const [inputValue, setInputValue] = useState('');

  useEffect(() => {
    // Fetch all tags from the API
    axios.get('https://localhost:7082/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }, []);

  const handleTagChange = (tagName, isChecked) => {
    if (isChecked) {
      setNewQuote(prevQuote => ({ ...prevQuote, Tags: [...prevQuote.Tags, tagName] }));
    } else {
      setNewQuote(prevQuote => ({ ...prevQuote, Tags: prevQuote.Tags.filter(name => name !== tagName) }));
    }
  };

  const getSuggestions = (value) => {
    const inputValueLowerCase = value.trim().toLowerCase();
    return allTags.filter(tag => tag.name.toLowerCase().includes(inputValueLowerCase));
  };

  const onSuggestionsFetchRequested = ({ value }) => {
    setSuggestions(getSuggestions(value));
  };

  const onSuggestionsClearRequested = () => {
    setSuggestions([]);
  };

  const addQuote = () => {
    console.log(newQuote);
    axios.post('https://localhost:7082/addNewQuote', newQuote, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then(response => console.log('Quote added successfully:', response.data))
      .catch(error => console.error('Error adding quote:', error));
  };
  const onSuggestionSelected = (event, { suggestion }) => {
    handleTagChange(suggestion.id, true);
    setInputValue('');
  };

  const onChange = (event, { newValue }) => {
    setInputValue(newValue);
  };

  const renderSuggestion = (suggestion) => (
    <div className='cursor-pointer'>
      {suggestion.name}
    </div>
  );

  const inputProps = {
    placeholder: 'Search a tag',
    value: inputValue,
    onChange: onChange,
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
          value={newQuote.Text}
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
          value={newQuote.Author}
          onChange={(e) => setNewQuote({ ...newQuote, Author: e.target.value })}
        />
      </div>
      <div className="mb-4">
        <label className="block text-white-800 text-sm font-semibold mb-2">Tags</label>
        <div className="mb-4 overflow-y-auto max-h-32">
        {allTags.map(tag => (
          <div key={tag.id} className="mb-2">
            <input
              type="checkbox"
              id={`tag-${tag.id}`}
              value={tag.name}
              checked={newQuote.Tags.includes(tag.id)}
              onChange={(e) => handleTagChange(tag.id, e.target.checked)}
            />
            <label className="ml-2 text-white-700" htmlFor={`tag-${tag.id}`}>{tag.name}</label>
          </div>
        ))}
      </div>

        <Autosuggest
          suggestions={suggestions}
          onSuggestionsFetchRequested={onSuggestionsFetchRequested}
          onSuggestionsClearRequested={onSuggestionsClearRequested}
          getSuggestionValue={(suggestion) => {suggestion.id}}
          renderSuggestion={renderSuggestion}
          onSuggestionSelected={onSuggestionSelected}
          inputProps={inputProps}
        />
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
