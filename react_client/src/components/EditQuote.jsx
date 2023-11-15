import React, { useState, useEffect } from 'react';
import axios from 'axios';

const EditQuote = ({ QuoteToEdit }) => {
  const [allTags, setAllTags] = useState([]);
  const [editedQuote, setEditedQuote] = useState({
    Id: '',
    Text: '',
    Author: '',
    Tags: [],
  });

  const fetchTags = () => {
    axios.get('https://localhost:7082/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }

  const fetchTagsByQuoteId = () => {
    axios.get(`https://localhost:7082/tags/quote=${QuoteToEdit.id}`)
      .then(response => {
        setEditedQuote(prevState => ({
          ...prevState,
          Tags: response.data.map(tag => tag.id),
        }));
      })
      .catch(error => console.error('Error fetching tags:', error));
  }

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

  const handleEditSubmit = (e) => {
    e.preventDefault();
    console.log(editedQuote);
    axios
      .put(`https://localhost:7082/quotes/edit/${editedQuote.Id}`, editedQuote)
      .then((response) => {
        console.log('Quote updated successfully:', response.data);
      })
      .catch((error) => {
        console.error('Error updating quote:', error);
      });
  };

  if (!QuoteToEdit) {
    return (<p>Select a quote, please</p>);
  }

  useEffect(() => {
    setEditedQuote({
      Id: QuoteToEdit.id || '',
      Text: QuoteToEdit.text || '',
      Author: QuoteToEdit.author || '',
      Tags: QuoteToEdit.tags || [],
    });
  }, [QuoteToEdit]);


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
        </div>
        <button type="submit" className="bg-blue-500 text-white px-6 py-3 rounded hover:bg-blue-600 focus:outline-none">
          Update Quote
        </button>
      </form>
    </div>
  );
};

export default EditQuote;
