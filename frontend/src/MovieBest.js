import React, {useState, useEffect} from 'react';
import { Container, Row, Col, Image, Button, Card } from 'react-bootstrap';
import './App.css';

export default function MovieBest({currentPage, setCurrentPage}){
  const [loading, setLoading] = useState(true);
  const [movie, setMovie] = useState(null);
  const [error, setError] = useState(null);
  

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url = `http://localhost:5001/api/movies?page=0&pageSize=100`;
        const response = await fetch(url);
        const data = await response.json(); 
        setMovie(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
      }
    };
    fetchData();
  }, [currentPage]);

  return (
    <div>
      {error ? (
        <div>{error}</div>
      ) : (
        loading || !movie ? (
          <div>Loading...</div>
        ) : (
          <Container>
            <Row>
              <Col xs>
                <h2 style={{ display: "flex", justifyContent: "center" }}>Top 30 Titles</h2>
                <div className="d-flex flex-wrap">
                  {movie.items
                    .filter(movie => movie.titleRating && movie.titleRating.numVotes >= 500)
                    .sort((a, b) => b.titleRating.averageRating - a.titleRating.averageRating)
                    .slice(0, 30)                  
                    .map((movie, index) => (
                    <div className="p-2" key={index}>
                        <Card style={{ width: '13rem', height: '20rem', overflow: 'hidden' }}>
                          <Card.Img variant="top" src={movie.omdbData.poster} alt="Movie Poster Missing" thumbnail style={{ objectFit: 'cover', width: '100%', height: '70%'}} />
                          <Card.Body>
                            <Card.Title>{movie.primaryTitle}</Card.Title>
                            <Card.Text>
                                {movie.titleRating && movie.titleRating.averageRating && <>{movie.titleRating.averageRating} &#9734; - </>}
                                {movie.genre}
                            </Card.Text>
                          </Card.Body>
                        </Card>
                    </div>
                  ))}
                </div>
              </Col>
            </Row>
          </Container>
        )
      )}
    </div>
);

};