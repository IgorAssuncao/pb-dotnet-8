import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./SignUp.css";
import { useHistory } from "react-router-dom";

function SignUp() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    let routerHistory = useHistory();

    function validateForm() {
        return email.length > 0 && password.length > 0 && username.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
        routerHistory.push('/perfil')
    }

    return (
        <div className="SignUp">
            <Form onSubmit={handleSubmit}>
            <Form.Group controlId="username" bsSize="large">
                <Form.Label>Usuário</Form.Label>
                    <Form.Control
                        autoFocus
                        type="text"
                        placeholder="Nome de usuário"
                        value={username}
                        onChange={e => setUsername(e.target.value)}
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
        </div>
    );
}

export default SignUp;
