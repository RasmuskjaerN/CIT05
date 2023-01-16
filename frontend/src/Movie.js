import React, { useState, useEffect } from "react";
import { Container, Row, Col, Image } from "react-bootstrap";
import "./App.css";

function Movie() {
  const [loading, setLoading] = useState(true);
  const [movie, setMovie] = useState(null);
  const [error, setError] = useState(null);
  const [search, setSearch] = useState("");
  const [tconst, setTconst] = useState('tt10850888');

  useEffect(() => {
    setError(null);
    async function fetchMovie() {
      try {
        const url = `http://localhost:5001/api/movies/` +tconst;
        const response = await fetch(url);
        if (!response.ok) {
          setError("Ups, There doent seem to exist anything with that title.");
          return;
        }
        const data = await response.json(); 
        setMovie(data);
        setLoading(false);
      } catch (error) {
        setError(error.message);
      }
    }

    fetchMovie();
  }, [tconst]);


  console.log(movie);
  return (
    <div className="page-margin">
            <div>
            <p></p>
          <input
                class="form-control"
                type="text"
                placeholder="Search.."
                value={search}
                onChange={e => setSearch(e.target.value)}/>
              <button type="submit" class="btn btn-primary" onClick={() => setTconst(search)} type="submit">Search</button>
          </div>
      {error ? (
        <div>{error}</div>  
      ) : loading || !movie ? (
        <div>Loading...</div>
      ) : (
        <Container>
          <h1>{movie.primaryTitle}</h1>
          <p>
            {" "}
            Original Title:{" "}
            {movie.originalTitle
              ? movie.originalTitle
              : movie.primaryTitle}{" "}
            &middot; Released: {movie.startYear ? movie.startYear : "Unknown"}{" "}
            &middot; Playing Time:{" "}
            {movie.runTimeMinutes ? movie.runTimeMinutes : "Unknown"} Minutes{" "}
          </p>
          <Row>
            <Col xs={4}>
              <Image src={movie.omdbData.poster} alt="Movie Poster" thumbnail />
            </Col>
            <Col xs={8}>
              <h2>Genres: </h2>

              <p>
                {movie.genre
                  .split(",")
                  .reduce((all, cur) => [all, " \u00B7 ", cur])}
              </p>
              <h3>Plot</h3>
              <div
                className="overflow-auto"
                style={{ maxHeight: "150px", width: "500px" }}
              >
                {movie.omdbData.plot}
              </div>
              <h3>Actors</h3>
              <p>Actor list is missing.</p>
            </Col>
          </Row>
          <Row>
            <Col xs={12}>
              <p>Movie Rating: {movie.titleRating.averageRating}</p>
              <form>
                <input type="number" min="0" max="10" step="1" />
                <input type="submit" value="Rate" />
              </form>
            </Col>
          </Row>
        </Container>
      )}
    </div>
  );
}

export default Movie;
