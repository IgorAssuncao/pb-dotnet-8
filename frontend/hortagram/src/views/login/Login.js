import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./Login.css";
import { Link, useHistory } from "react-router-dom";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    let routerHistory = useHistory();

    function validateForm() {
        return email.length > 0 && password.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
        routerHistory.push('/perfil')
    }

    return (
        <div className="Login">
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="email" bsSize="large">
                <Form.Label>Email</Form.Label>
                    <Form.Control
                        autoFocus
                        type="email"
                        placeholder="name@example.com"
                        value={email}
                        validateForm="email"
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
                    Login
                </Button>
                <div className="div-signup">
                    Não tem uma conta? <Link to="signup" className="btn-signup">Cadastre-se</Link>
                </div>
            </Form>
        </div>
    );
}

export default Login;
