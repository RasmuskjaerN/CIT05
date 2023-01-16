import React from 'react';
import { Pagination } from 'react-bootstrap';
import Menu from './Menu';

const maxPage = 8222;

const Pagin = () => {
  const [currentPage, setCurrentPage] = React.useState(0);

  return (
    <div>
        <h2 style={{ display: "flex", justifyContent: "center" }}> All Titels - Page {currentPage+1}</h2>
        <Pagination style={{ display: "flex", justifyContent: "center" }}>
        <Pagination.First disabled={currentPage === 0} onClick={() => setCurrentPage(0)} />
        <Pagination.Prev disabled={currentPage === 0} onClick={() => setCurrentPage(currentPage - 1)} />
        <Pagination.Item active={true}>
          {currentPage+1}
        </Pagination.Item>
        <Pagination.Next disabled={currentPage === maxPage} onClick={() => setCurrentPage(currentPage + 1)} />
        <Pagination.Last disabled={currentPage === maxPage} onClick={() => setCurrentPage(maxPage)} />
      </Pagination>
      <Menu currentPage={currentPage} setCurrentPage={setCurrentPage}/>
    </div>
  );
}

export default Pagin;
