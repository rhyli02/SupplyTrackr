import React, { useState, useEffect } from 'react'

const Preloader = () => {
    const [ isLoading, setIsLoading ] = useState(true)

    useEffect(() => {
        const timer = setTimeout(() => {
            setIsLoading(false);
        }, 350);

        return() => clearTimeout();
    }, []);

  return (
    isLoading && (
        <div id="preloader">
            <div id="status">Loading...</div>
        </div>
    )
  );
};

export default Preloader
