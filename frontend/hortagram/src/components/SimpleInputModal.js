import React, { useState } from "react";
import { Button, Modal, Form } from "react-bootstrap";

function SimpleInputModal(props) {
    const [username, setUsername] = useState("");

    function validateForm() {
        return username.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
        props.onHide()
    }

    return (
        <Modal
            {...props}
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {props.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleSubmit}>
                    <Form.Group controlId="username" bsSize="large">
                        <Form.Label>{props.label}</Form.Label>
                        <Form.Control
                            value={username}
                            placeholder={props.placeholder}
                            onChange={e => setUsername(e.target.value)}
                            type="text"
                        />
                    </Form.Group>
                    <Button block bsSize="large" disabled={!validateForm()} type="submit">
                        {props.buttonText}
                    </Button>
                </Form>
            </Modal.Body>
        </Modal>
    );
}

export default SimpleInputModal;