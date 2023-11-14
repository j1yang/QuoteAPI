import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';

const QuoteList = ({handleQuoteClick}) => {
  const [quotes, setQuotes] = useState([]);
  const [allTags, setAllTags] = useState([]);
  const searchFilterRef = useRef('');
  const quoteIdRef = useRef('');
  const tagRef = useRef('');
  const [forceUpdate, setForceUpdate] = useState(0);

  const updateFetch =() => {
    if(searchFilterRef.current.value === 'all'){
      fetchQuotes();
    }else if(searchFilterRef.current.value === 'tag'){
      fetchQuotesByTag();
      
    }else if(searchFilterRef.current.value === 'id'){
      fetchQuoteById();
    }else{
      console.log('not fetching now..', searchFilterRef.current.value)
    }
  }

  const fetchQuotes = () => {
    axios.get('https://localhost:7082/quotes')
        .then(response => {
          setQuotes(response.data);
        })
        .catch(error => console.error('Error fetching quotes:', error));
    //console.log('fetching All Quotes')
  }

  const fetchTag = () => {
    axios.get('https://localhost:7082/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }

  const fetchQuotesByTag = () => {
    if (tagRef.current.value) {
      axios.get(`https://localhost:7082/quotes/tag=${tagRef.current.value}`)
        .then(response => {
          setQuotes(response.data);
          setForceUpdate(prev => prev + 1);

        })
        .catch(error => console.error(`Error fetching quotes for tag '${selectedTag}':`, error));
        //console.log('fetching Tag Quotes')
    }

  }

  const fetchQuoteById = () => {
    if (quoteIdRef.current.value) {
      axios.get(`https://localhost:7082/quotes/${quoteIdRef.current.value}`)
        .then(response => {
          setQuotes([response.data]);
        })
        .catch(error => console.error(`Error fetching quote with ID '${quoteIdRef.current.value}':`, error));
        //console.log('fetching Id Quotes')
    }
  }

  useEffect(() => {
    fetchTag();
    const intervalId = setInterval(updateFetch, 100);

    return () => clearInterval(intervalId);
  }, [forceUpdate]);

  const handleSearchFilterChange = (event) => {
    //console.log('Selected filter:', event.target.value);
    setQuotes([]); // Clear existing quotes when changing the filter
  }

  return (
    <div className="p-8 rounded shadow">
      <h2 className="text-2xl font-bold mb-4">Quote List</h2>
      <div className="mb-4">
      <label htmlFor="searchFilter">Search Filter:</label>
      <select id="searchFilter" ref={searchFilterRef} onChange={handleSearchFilterChange}>
          <option value="all">Search All</option>
          <option value="tag">Search by Tag</option>
          <option value="id">Search by ID</option>
        </select>

        {searchFilterRef.current.value === 'tag' && (
          <div>
          <label>Select Tag:</label>
          <select ref={tagRef}>
            <option value="">-- Select Tag --</option>
            {allTags.map(tag => (
              <option key={tag.id} value={tag.name}>{tag.name}</option>
            ))}
          </select>
        </div>
        )}

        {searchFilterRef.current.value === 'id' && (
          <div>
          <label htmlFor="quoteId">Enter Quote ID:</label>
          <input placeholder='enter id' type="text" id="quoteId" ref={quoteIdRef} />
        </div>
        )}

        
      </div>

      <ul>
        {(quotes) && quotes.map(quote => (
          <li key={quote.id} className="mb-2 hover:cursor-pointer hover:bg-gray-200	hover:text-black" onClick={() => handleQuoteClick(quote)}>
            <p className="text-white-800"><strong>"{quote.text}"</strong></p>
            <p className="text-gray-500">- {quote.author}</p>
          </li>
        ))}
        {quotes.length === 0 && <li><p key={-1}>There is no quotes...</p></li>}
      </ul>
    </div>
  );
};

export default QuoteList;
