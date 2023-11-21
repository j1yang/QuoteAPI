import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ManageTag = (props) => {
  const [existingTags, setExistingTags] = useState([]);
  const [inputValue, setInputValue] = useState('');

  //when component mounted
  useEffect(() => {
    // GET all tags
    axios.get('https://localhost:7082/tags')
      .then(response => {
        setExistingTags(response.data) 
        console.log(response.data)})
      .catch(error => console.error('Error fetching tags:', error));
  }, []);

  //Add New Tag
  const addTag = () => {
    // Check if inputValue is not empty
    if (inputValue.trim() === '') {
      console.error('Tag name cannot be empty');
      return;
    }

    // Create a new tag object
    const newTag = {
      name: inputValue.trim(), 
    };

    // POST new tag
    axios.post('https://localhost:7082/addNewTag', newTag)
      .then(response => {
        setExistingTags([...existingTags, response.data]); 
        // Clear the input value
        setInputValue('');
      })
      .catch(error => console.error('Error adding tag:', error));
  };

  return (
    <div className="max-w-md mx-auto p-4 bg-gray rounded shadow">
      <h1 className="text-2xl font-bold mb-4">Tag Management</h1>
      <div className="mb-4">
        <select
          value={''}
          onChange={(e) => setInputValue(e.target.value)}
          className="w-full p-2 border rounded"
        >
          <option value="" disabled>Tag list</option>
          {existingTags.map(tag => (
            <option key={tag.id} value={tag.name}>{tag.name}</option>
          ))}
        </select>
      </div>
      <div>
        <label className="block text-sm font-semibold mb-2">Add Tag:</label>
        <div className="flex items-center">
          <input
            type="text"
            value={inputValue}
            onChange={(e) => setInputValue(e.target.value)}
            placeholder="Enter tag name..."
            className="w-full p-2 border rounded mr-2"
          />
          <button onClick={addTag} className="w-[100px] bg-blue-500 text-white p-1 rounded">Add Tag</button>
        </div>
      </div>
    </div>
  );
};

export default ManageTag;
