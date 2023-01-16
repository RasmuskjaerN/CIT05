import React, {useState, useEffect} from 'react';
import { Container, Row, Col, Card } from 'react-bootstrap';
import './App.css';
export default function Menu({currentPage, setCurrentPage}){
  const [loading, setLoading] = useState(true);
  const [movie, setMovie] = useState(null);
  const [error, setError] = useState(null);
//test
  useEffect(() => {
    const fetchData = async () => {
      try {
        const url = `http://localhost:5001/api/movies?page=`+currentPage+`&pageSize=10`;
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
                <div className="d-flex flex-wrap">
                  {movie.items.map((movie, index) => (
                    <div className="p-2" key={index}>
                        <Card style={{ width: '13rem', height: '20rem', overflow: 'hidden' }}>
                          {movie.omdbData && movie.omdbData.poster ? <Card.Img variant="top" src={movie.omdbData.poster} alt="Movie Poster" thumbnail style={{ objectFit: 'cover', width: '100%', height: '70%'}} /> : <div> ERROR: POSTER MISSING </div> }
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
