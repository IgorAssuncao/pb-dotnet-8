import React from "react";
import { Row, Col, CardGroup, Card } from "react-bootstrap";
import "./PerfilPosts.css";

function PerfilPosts(props) {
    if (props.list > 0) {
        const cards = []
        for (let image of props.list) {
            cards.push(
                <Col xs={6} md={4}>
                    <Card >
                        <Card.Img variant="top" src={image} />
                    </Card>
                </Col>
            )
        }
        return (
            <div>
                <Row>
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