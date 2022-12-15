import React, { useState } from 'react';
import userLoggedIn from './UserHandler';

function SideBoxes() {
  const [isExpandedBookmark, setIsExpandedBookmark] = useState(false);
  const [isExpandedHistory, setIsExpandedHistory] = useState(false);
  return (
    <div>{userLoggedIn &&
      <div>
      <div
        style={{
          width: isExpandedBookmark ? '30%' : '5%',
          height: '50%',
          background: 'lightblue',
          border: '1px solid black',
          position: 'fixed',
          right: 0,
          top: 0,
          transition: 'width 0.5s ease-in-out',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          zIndex: '9',
        }}
        onClick={() => setIsExpandedBookmark(!isExpandedBookmark)}
      >
        {isExpandedBookmark ? '10 latest Bookmarkes' : <div style={{ transform: 'rotate(90deg)' }}>Bookmarkes</div>}
      </div>
      <div
        style={{
          width: isExpandedHistory ? '30%' : '5%',
          height: '50%',
          background: 'lightgray',
          border: '1px solid black',
          position: 'fixed',
          right: 0,
          bottom: 0,
          transition: 'width 0.5s ease-in-out',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          zIndex: '9',
        }}
        onClick={() => setIsExpandedHistory(!isExpandedHistory)}
      >
        {isExpandedHistory ? '10 latest Search History' : <div style={{ transform: 'rotate(90deg)' }}>History</div>}
      </div>
    </div>
}</div>
  );
}
export default SideBoxes;
