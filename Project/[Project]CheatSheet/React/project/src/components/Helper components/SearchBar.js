import React, { useState } from 'react';

function SearchBar(props) {
  const [searchTerm, setSearchTerm] = useState("");

  const handleChange = (event) => {
    event.preventDefault();
    setSearchTerm(event.target.value);
  }



  return (
    <form>
      <input className='search-bar'
        type="text" 
        placeholder="Search..." 
        value={searchTerm} 
        onChange={handleChange} 
      />
    </form>
  );
}

export default SearchBar;