import React, { useState, useEffect } from 'react';
import axios from 'axios';

const EditQuote = ({ QuoteToEdit }) => {
  const [allTags, setAllTags] = useState([]);
  const [editedQuote, setEditedQuote] = useState({
    id: '',
    text: '',
    author: '',
    tag: '',
  });

  const fetchTag = () => {
    axios.get('https://localhost:7082/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }

  const fetchTagbyQuoteId = () => {
    axios.get(`https://localhost:7082/tags/quote=${QuoteToEdit.id}`)
      .then(response => {
        //console.log(response.data[0].name)
        setEditedQuote(prevState => ({
          ...prevState,
          tag: response.data[0].name
        }));
      })
      .catch(error => console.error('Error fetching tags:', error));
  }

  useEffect(() => {
    fetchTag();
    if (QuoteToEdit.id) {
      fetchTagbyQuoteId();
    }
  }, [QuoteToEdit.id]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setEditedQuote((prev) => ({ ...prev, [name]: value }));
  };

  const handleEditSubmit = (e) => {
    e.preventDefault();

    // Make an API request to update the quote
    axios
      .put(`https://localhost:7082/quotes/${editedQuote.id}`, editedQuote)
      .then((response) => {
        console.log('Quote updated successfully:', response.data);
        // Optionally, you can reset the form or perform other actions
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
      id: QuoteToEdit.id || '',
      text: QuoteToEdit.text || '',
      author: QuoteToEdit.author || '',
      tag: QuoteToEdit.tag || '',
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
        name="text"
        value={editedQuote.text}
        onChange={handleInputChange}
        className="w-full border border-gray-300 px-3 py-2 rounded focus:outline-none focus:border-blue-500 resize-none"
        rows="5" // You can adjust the number of rows as needed
      />
    </div>
    <div className="mb-6">
      <label htmlFor="editedAuthor" className="block text-white-600 font-semibold mb-2">Author:</label>
      <input
        type="text"
        id="editedAuthor"
        name="author"
        value={editedQuote.author}
        onChange={handleInputChange}
        className="w-full border border-gray-300 px-3 py-2 rounded focus:outline-none focus:border-blue-500"
      />
    </div>
    <div className="mb-6">
      <label htmlFor="editedTag" className="block text-white-600 font-semibold mb-2">Tag:</label>
      <select
        id="editedTag"
        name="tag"
        value={editedQuote.tag}
        onChange={handleInputChange}
        className="w-full border border-gray-300 px-3 py-2 rounded focus:outline-none focus:border-blue-500"
      >
        <option value="">-- Select Tag --</option>
        {allTags.map((tag) => (
          <option key={tag.id} value={tag.name}>
            {tag.name}
          </option>
        ))}
      </select>
    </div>
    <button type="submit" className="bg-blue-500 text-white px-6 py-3 rounded hover:bg-blue-600 focus:outline-none">
      Update Quote
    </button>
  </form>
</div>


  );
};

export default EditQuote;
