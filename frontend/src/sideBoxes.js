import React from 'react';
import History from './UserHistory.js';
import Bookmarks from './UserBookmarks';
import { useState } from 'react';
import useLocalStorage from './useLocalStorage.js';

function SideBoxes(props) {
  const [isExpandedBookmark, setIsExpandedBookmark] = useState(false);
  const [isExpandedHistory, setIsExpandedHistory] = useState(false);
  const [uid, setUid] = useLocalStorage("uid","");
  const [token, setToken] = useLocalStorage("token", "");

  return (
    token ? (
    <div>
      {
      <div>
      <div
        style={{
          width: isExpandedBookmark ? '30%' : '5%',
          height: '50%',
          background: 'darkgray',
          border: '1px solid black',
          position: 'fixed',
          right: 0,
          top: 0,
          transition: 'width 0.2s ease-in-out',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          zIndex: '9',
        }}
        onClick={() => setIsExpandedBookmark(!isExpandedBookmark)}
      >
        {isExpandedBookmark ? 
        <div>10 latest Bookmarkes <Bookmarks /></div>
        : <div style={{ transform: 'rotate(90deg)' }}>Bookmarkes</div>}
      </div>
      <div
        style={{
          width: isExpandedHistory ? '30%' : '5%',
          height: '50%',
          background: 'darkgray',
          border: '1px solid black',
          position: 'fixed',
          right: 0,
          top: '50%',
          transition: 'width 0.2s ease-in-out',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          zIndex: '9',
        }}
        onClick={() => setIsExpandedHistory(!isExpandedHistory)}
      >
        {isExpandedHistory ? (
          <div>10 latest History <History /></div>
        ) : (
          <div style={{ transform: 'rotate(90deg)' }}>History</div>
        )}
      </div>
      </div>
    }
    </div>
    ) : (null)
  );
}

export default SideBoxes;
