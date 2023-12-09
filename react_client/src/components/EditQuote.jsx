import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Autosuggest from 'react-autosuggest';

const EditQuote = ({ QuoteToEdit, config }) => {
  const [allTags, setAllTags] = useState([]);
  const [suggestions, setSuggestions] = useState([]);
  const [inputValue, setInputValue] = useState('');
  const [editedQuote, setEditedQuote] = useState({
    Id: '',
    Text: '',
    Author: '',
    Tags: [],
  });

  //GET all tags
  const fetchTags = () => {
    axios.get('https://localhost:7082/api/tags',config)
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }

  //GET Tags by qutoe id
  const fetchTagsByQuoteId = () => {
    axios.get(`https://localhost:7082/api/tags/quote=${QuoteToEdit.id}`,config)
      .then(response => {
        setEditedQuote(prevState => ({
          ...prevState,
          Tags: response.data.map(tag => tag.id),
        }));
      })
      .catch(error => console.error('Error fetching tags:', error));
  }

  // Load Edit quote input value
  useEffect(() => {
    fetchTags();
    if (QuoteToEdit.id) {
      fetchTagsByQuoteId();
    }
  }, [QuoteToEdit.id]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setEditedQuote(prev => ({ ...prev, [name]: value }));
  };

  const handleTagChange = (tagId, isChecked) => {
    if (isChecked) {
      setEditedQuote(prevState => ({ ...prevState, Tags: [...prevState.Tags, tagId] }));
    } else {
      setEditedQuote(prevState => ({ ...prevState, Tags: prevState.Tags.filter(id => id !== tagId) }));
    }
  };

  // PUT edit quote
  const handleEditSubmit = (e) => {
    e.preventDefault();
    console.log(editedQuote);
    axios
      .put(`https://localhost:7082/api/quotes/edit/${editedQuote.Id}`, editedQuote,config)
      .then((response) => {
        console.log('Quote updated successfully:', response.data);
      })
      .catch((error) => {
        console.error('Error updating quote:', error);
      });
  };

  //render message when quote is not selected
  if (!QuoteToEdit) {
    return (<p>Select a quote, please</p>);
  }

  //initialize Quote to be edited
  useEffect(() => {
    setEditedQuote({
      Id: QuoteToEdit.id || '',
      Text: QuoteToEdit.text || '',
      Author: QuoteToEdit.author || '',
      Tags: QuoteToEdit.tags || [],
    });
  }, [QuoteToEdit]);

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
    <div className="p-8 rounded shadow bg-gray">
      <h2 className="text-3xl font-bold mb-6 text-white">Edit Quote</h2>
      <form onSubmit={handleEditSubmit}>
        <div className="mb-6">
          <label htmlFor="editedText" className="block text-white-600 font-semibold mb-2">Text:</label>
          <textarea
            id="editedText"
            name="Text"
            value={editedQuote.Text}
            onChange={handleInputChange}
            className="w-full border border-gray-300 px-3 py-2 rounded focus:outline-none focus:border-blue-500 resize-none"
            rows="5" 
          />
        </div>
        <div className="mb-6">
          <label htmlFor="editedAuthor" className="block text-white-600 font-semibold mb-2">Author:</label>
          <input
            type="text"
            id="editedAuthor"
            name="Author"
            value={editedQuote.Author}
            onChange={handleInputChange}
            className="w-full border border-gray-300 px-3 py-2 rounded focus:outline-none focus:border-blue-500"
          />
        </div>
        <div className="mb-6">
          <label className="block text-white-600 font-semibold mb-2">Tags:</label>
          <div className="mb-4 overflow-y-auto max-h-32">
            {allTags.map(tag => (
              <div key={tag.id} className="mb-2">
                <input
                  type="checkbox"
                  id={`tag-${tag.id}`}
                  value={tag.name}
                  checked={editedQuote.Tags.includes(tag.id)}
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
        <button type="submit" className="bg-blue-500 text-white px-6 py-3 rounded hover:bg-blue-600 focus:outline-none">
          Update Quote
        </button>
      </form>
    </div>
  );
};

export default EditQuote;
