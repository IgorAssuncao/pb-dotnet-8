import React, { useState } from "react";
import { Button, Modal, Form } from "react-bootstrap";
import SimpleAlertModal from "./SimpleAlertModal";
import Loading from "./Loading";
import api from '../services/api'
import { useHistory } from "react-router-dom";

function SimpleInputModal(props) {
    const [firstName, setFirstName] = useState("");
    const [lastname, setLastname] = useState("");
    const [loading, setLoading] = React.useState(false);
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    let routerHistory = useHistory();

    function validateForm() {
        return firstName.length > 0 && lastname.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
        setLoading(true)
        const id = localStorage.getItem('id');
        api.put(`/User/${id}`, {
            firstName: firstName,
            lastName: lastname
        })
        .then(function (response) {
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
            props.onHide()
            routerHistory.push(`/perfil/${localStorage.getItem('id')}`)
        });
    }

    return (
        <div>
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
                        <Form.Group controlId="firstName" bsSize="large">
                            <Form.Label>{props.firstName}</Form.Label>
                            <Form.Control
                                value={firstName}
                                onChange={e => setFirstName(e.target.value)}
                                type="text"
                            />
                        </Form.Group>
                        <Form.Group controlId="lastname" bsSize="large">
                            <Form.Label>{props.lastname}</Form.Label>
                            <Form.Control
                                value={lastname}
                                onChange={e => setLastname(e.target.value)}
                                type="text"
                            />
                        </Form.Group>
                        <Button block bsSize="large" disabled={!validateForm()} type="submit">
                            {props.buttonText}
                        </Button>
                    </Form>
                </Modal.Body>
            </Modal>


            <SimpleAlertModal
                title="Oops!"
                label="Ocorreu um erro ao atualizar suas informações"
                buttonText="Ok"
                show={alertModalShow}
                onHide={() => setAlertModalShow(false)}
            />
            <Loading loading={loading} />
        </div>
    );
}

export default SimpleInputModal;