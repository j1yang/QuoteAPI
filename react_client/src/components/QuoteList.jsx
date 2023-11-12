import React, { useState, useEffect } from 'react';
import axios from 'axios';

const QuoteList = (props) => {
  const [quotes, setQuotes] = useState([]);

  useEffect(() => {
    // Fetch quotes from the API
    axios.get('https://localhost:7082/quotes')
      .then(response => setQuotes(response.data))
      .catch(error => console.error('Error fetching quotes:', error));
  }, []);

  return (
    <div className="p-8 rounded shadow">
      <h2 className="text-2xl font-bold mb-4">Quote List</h2>
      <ul>
        {quotes.map(quote => (
          <li key={quote.id} className="mb-2">
            <p className="text-white-800"><strong>"{quote.text}"</strong></p>
            <p className="text-gray-500">- {quote.author}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default QuoteList;
