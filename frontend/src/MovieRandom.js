import React, {useState, useEffect} from 'react';
import { Container, Row, Col, Image, Button, Card } from 'react-bootstrap';
import './App.css';

export default function MovieRandom({currentPage, setCurrentPage}){
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
                <h2 style={{ display: "flex", justifyContent: "center" }}>30 Random Titles</h2>
                <div className="d-flex flex-wrap">
                  {movie.items
                    .filter(movie => movie.titleRating[0])
                    .sort(() => Math.random() - 0.5)
                    .slice(0, 30)                  
                    .map((movie, index) => (
                    <div className="p-2" key={index}>
                        <Card style={{ width: '13rem', height: '20rem', overflow: 'hidden' }}>
                          <Card.Img variant="top" src={movie.omdbData[0].poster} alt="Movie Poster Missing" thumbnail style={{ objectFit: 'cover', width: '100%', height: '70%'}} />
                          <Card.Body>
                            <Card.Title>{movie.primaryTitle}</Card.Title>
                            <Card.Text>
                                {movie.titleRating[0] && movie.titleRating[0].averageRating && <>{movie.titleRating[0].averageRating} &#9734; - </>}
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