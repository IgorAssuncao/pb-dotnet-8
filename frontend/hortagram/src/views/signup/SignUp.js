import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./SignUp.css";
import { useHistory } from "react-router-dom";
import api from '../../services/api'
import SimpleAlertModal from "../../components/SimpleAlertModal";

function SignUp() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [modalShow, setModalShow] = React.useState(false);
    let routerHistory = useHistory();

    function validateForm() {
        return email.length > 0 && password.length > 0
            && firstName.length > 0 && lastName.length > 0;
    }

    async function handleSubmit(event) {
        event.preventDefault();
        api.post('/User', {
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: password
        }).then(function (response) {
            routerHistory.push('/login')
        }).catch(function (error) {
            setModalShow(true)
        });
    }

    return (
        <div className="SignUp">
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="firstName" bsSize="large">
                    <Form.Label>Usuário</Form.Label>
                    <Form.Control
                        autoFocus
                        type="text"
                        placeholder="Nome"
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group controlId="lastName" bsSize="large">
                    <Form.Label>Usuário</Form.Label>
                    <Form.Control
                        autoFocus
                        type="text"
                        placeholder="Sobrenome"
                        value={lastName}
                        onChange={e => setLastName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group controlId="email" bsSize="large">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                        autoFocus
                        type="email"
                        placeholder="name@example.com"
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                    />
                </Form.Group>
                <Form.Group controlId="password" bsSize="large">
                    <Form.Label>Senha</Form.Label>
                    <Form.Control
                        value={password}
                        placeholder="Senha"
                        onChange={e => setPassword(e.target.value)}
                        type="password"
                    />
                </Form.Group>
                <Button block bsSize="large" disabled={!validateForm()} type="submit">
                    Cadastrar
                </Button>
            </Form>

            <SimpleAlertModal
                title="Oops!"
                label="Erro ao cadastrar"
                buttonText="Ok"
                show={modalShow}
                onHide={() => setModalShow(false)}
            />
        </div>
    );
}

export default SignUp;
