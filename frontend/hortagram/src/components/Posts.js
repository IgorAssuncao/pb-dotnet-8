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

        api.post(`/Comment`, {
            "UserId": localStorage.getItem('id'),
            "PostId": id,
            "Content": comment
        }).then(function (response) {
            window.location.reload(true);
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
        setComment("")
    }

    function deleteComment(id) {
        setLoading(true)

        api.delete(`/Comment/${id}`).then(function (response) {
            console.log(response)
            window.location.reload(true);
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    if (props.list.length > 0) {
        const cards = []
        for (let info of props.list) {
            const comments = []
            for (let comment1 of info.comments) {
                comments.push(
                    <div className="infoPosts">
                        <p><b>id {comment1.id}:</b></p>
                        <p>{comment1.content}</p>
                        {comment1.userId == localStorage.getItem('id') 
                         ? <Button onClick={() => deleteComment(comment1.id)}>deletar</Button>
                         : ""
                        }
                    </div>
                )
            }
            const commentForm = props.canComment ?
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
            : ""

            cards.push(
                <Col>
                    <Card>
                        <Card.Img variant="top" className="imagePost" src={info.photoUrl} />
                        <h5>{info.description}</h5>
                        {comments}
                        {commentForm}
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