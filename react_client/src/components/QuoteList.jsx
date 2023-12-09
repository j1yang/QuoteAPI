import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import { FaThumbsUp } from 'react-icons/fa'; 

const QuoteList = ({handleQuoteClick, config}) => {
  const [quotes, setQuotes] = useState([]);
  const [allTags, setAllTags] = useState([]);
  const searchFilterRef = useRef('');
  const quoteIdRef = useRef('');
  const tagRef = useRef('');
  const [forceUpdate, setForceUpdate] = useState(0);
  const [likes, setLikes] = useState({});



  //POST Quote like click event.
  const handleLikeClick = async (quoteId) => {
    try {
      await axios.post(`https://localhost:7082/api/Like/${quoteId}`,config);
      fetchLikes();

    } catch (error) {
      console.error('Error liking quote:', error);
    }
  };
  
  //Update quotes by filter. will be called constantly
  const updateFetch = () => {
    if (searchFilterRef.current.value === 'all') {
      fetchQuotes();
    } else if (searchFilterRef.current.value === 'tag') {
      fetchQuotesByTag();
    } else if (searchFilterRef.current.value === 'id') {
      fetchQuoteById();
    } else if (searchFilterRef.current.value === 'mostliked') {
      fetchMostLikedQuotes();
    }else if (searchFilterRef.current.value === 'leastliked') {
      fetchLeastLikedQuotes();
    }else if (searchFilterRef.current.value === '15plusliked') {
      fetch15PlusLikedQuotes();
    } else {
      console.log('not fetching now...', searchFilterRef.current.value);
    }
  };

  //GET ten most liked quotes
  const fetchMostLikedQuotes = () => {
    axios.get('https://localhost:7082/api/quotes/mostliked',config)
      .then(response => {
        setQuotes(response.data);
      })
      .catch(error => console.error('Error fetching most liked quotes:', error));
  };
  //GET ten least liked quotes
  const fetchLeastLikedQuotes = () => {
    axios.get('https://localhost:7082/api/quotes/leastliked',config)
      .then(response => {
        setQuotes(response.data);
      })
      .catch(error => console.error('Error fetching most liked quotes:', error));
  };
  //GET 15 plus liked quotes
  const fetch15PlusLikedQuotes = () => {
    axios.get('https://localhost:7082/api/quotes/15pluslike',config)
      .then(response => {
        setQuotes(response.data);
      })
      .catch(error => console.error('Error fetching most liked quotes:', error));
  };
  // GET quotes
  const fetchQuotes = () => {
    axios.get('https://localhost:7082/api/quotes',config)
        .then(response => {
          setQuotes(response.data);
        })
        .catch(error => console.error('Error fetching quotes:', error));
    //console.log('fetching All Quotes')
  }
  // GET likes
  const fetchLikes = () => {
    axios.get('https://localhost:7082/api/Likes')
        .then(response => {
          {
            setLikes(response.data)
          };
        })
        .catch(error => console.error('Error fetching quotes:', error));
    //console.log('fetching All Quotes')
  }

  //GET all Tags
  const fetchTag = () => {
    axios.get('https://localhost:7082/api/tags')
      .then(response => setAllTags(response.data))
      .catch(error => console.error('Error fetching tags:', error));
  }

  //GET Quotes by tag
  const fetchQuotesByTag = () => {
    if (tagRef.current.value) {
      axios.get(`https://localhost:7082/api/quotes/tag=${tagRef.current.value}`, config)
        .then(response => {
          setQuotes(response.data);
          setForceUpdate(prev => prev + 1);

        })
        .catch(error => console.error(`Error fetching quotes for tag '${selectedTag}':`, error));
        //console.log('fetching Tag Quotes')
    }

  }

  //GET quote by id
  const fetchQuoteById = () => {
    if (quoteIdRef.current.value) {
      axios.get(`https://localhost:7082/api/quotes/${quoteIdRef.current.value}`, config)
        .then(response => {
          setQuotes([response.data]);
        })
        .catch(error => console.error(`Error fetching quote with ID '${quoteIdRef.current.value}':`, error));
        //console.log('fetching Id Quotes')
    }
  }


  // Rreact useEffect hook that handle quote refersh
  useEffect(() => {
    if(config){
      fetchTag();
      fetchLikes();

      // call update fetch every 1500ms
      const intervalId = setInterval(updateFetch, 1500);
      return () => clearInterval(intervalId);
    
    }else{
      console.log('no config')
    }
  }, [forceUpdate,config]);
  
  

  // Reset quotes when filter is changed
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
          <option value="mostliked">Search most liked quotes</option>
          <option value="leastliked">Search least liked quotes</option>
          <option value="15plusliked">Search 15+ liked quotes</option>

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

      <ul className='overflow-y-auto h-[600px]'>
        {(quotes) && quotes.map(quote => (
          <li key={quote.id} className="mb-2 hover:cursor-pointer hover:bg-gray-200	hover:text-black" onClick={() => handleQuoteClick(quote)}>
            <div className='flex justify-between h-[45px]'>
              <p className="text-white-800"><strong>"{quote.text}"</strong></p>
              <div className='w-[50px] h-[10px] bg-transparent border-none m-0 p-0 flex my-2' onClick={() => handleLikeClick(quote.id)}>
                <FaThumbsUp /> 
                <p className='ml-2 decoration-transparent'>{(likes?.filter(like => like.quoteId === quote.id) || []).length}</p>
              </div>
            </div>
            <p className="text-gray-500">- {quote.author}</p>
          </li>
        ))}
        {quotes.length === 0 && <li><p key={-1}>There are no quotes...</p></li>}
      </ul>
    </div>
  );
};

export default QuoteList;
