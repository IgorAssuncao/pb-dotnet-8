import React, { useState } from "react";
import { Row, Col, Card, Form, Button } from "react-bootstrap";
import "./Posts.css";
import Loading from "./Loading";
import SimpleAlertModal from "./SimpleAlertModal";
import api from '../services/api'

function Posts(props) {
    const [comment, setComment] = useState("");
    const [loading, setLoading] = React.useState(false);
    const [alertModalShow, setAlertModalShow] = React.useState(false);

    function validateForm() {
        return comment.length > 0;
    }

    function handleSubmit(event, id) {
        event.preventDefault();
        
        setLoading(true)
        const formData = new FormData();
        formData.append("UserId", localStorage.getItem('id'));
        formData.append("PostId", id);
        formData.append("Content", comment);
        
        api.post(`/Comment`, formData, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`,
                "Content-Type": "multipart/form-data"
            }
        }).then(function (response) {
            console.log(response)
        }).catch(function (error) {
            console.log(error)
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
        setComment("")
    }

    if (props.list.length > 0) {
        const cards = []
        for (let info of props.list) {
            const comments = []
            for (let comment1 of props.list) {
                comments.push(
                    <div className="infoPosts">
                        {/* <p><b>{comment1.firstName} {comment1.lastname}:</b></p>
                        <p>{comment1.comment}</p> */}
                        <p><b>meu nome:</b></p>
                        <p>comentario</p>
                    </div>
                )
            }
            cards.push(
                <Col>
                    <Card>
                        <Card.Img variant="top" className="imagePost" src="assets/quadrado_preto.png" />
                        {comments}
                        <Form onSubmit={(e) => handleSubmit(e, info.id)}>
                            <Form.Group controlId="comment" bsSize="large">
                                <Form.Control
                                    value={comment}
                                    onChange={e => setComment(e.target.value)}
                                    type="text"
                                />
                            </Form.Group>
                            <Button block bsSize="large" disabled={!validateForm()} type="submit">
                                Comentar
                            </Button>
                        </Form>
                    </Card>
                </Col>
            )
        }
        return (
            <div>
                <Row className="posts">
                    {cards}
                </Row>

                <SimpleAlertModal
                    title="Oops!"
                    label="Ocorreu um erro ao carregar"
                    buttonText="Ok"
                    show={alertModalShow}
                    onHide={() => setAlertModalShow(false)}
                />
                <Loading loading={loading} />
            </div>
        );
    } else {
        return (
            <div>
                <h1>Sem posts</h1>
            </div>
        );
    }
}

export default Posts;