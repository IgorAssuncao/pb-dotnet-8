import React from "react";
import { Button, Modal } from "react-bootstrap";

function SimpleAlertModal(props) {

    function handleSubmit() {
        props.onHide()
    }

    return (
        <Modal
            {...props}
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    {props.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>{props.label}</Modal.Body>
            <Modal.Footer>
                <Button variant="primary" onClick={handleSubmit}>
                    {props.buttonText}
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default SimpleAlertModal;