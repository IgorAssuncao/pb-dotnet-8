import React from "react";
import { Row, Col, Card } from "react-bootstrap";
import "./PerfilPosts.css";

function PerfilPosts(props) {
    if (props.posts.length > 0) {
        const cards = []
        for (let info of props.posts) {
            cards.push(
                <Col>
                    <Card >
                        <Card.Img variant="top" className="imagePost" src={info.photoUrl} />
                        <h5>{info.description}</h5>
                    </Card>
                </Col>
            )
        }
        return (
            <div>
                <Row className="posts">
                    {cards}
                </Row>
            </div>
        );
    } else {
        return (
            <div>
                <h1>Sem Posts</h1>
            </div>
        );
    }
}

export default PerfilPosts;