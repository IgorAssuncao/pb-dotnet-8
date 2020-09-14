import React, { useState } from "react";
import { Button, Form, Spinner, Modal } from "react-bootstrap";
import "./Login.css";
import { Link, useHistory } from "react-router-dom";
import api from '../../services/api'
import SimpleAlertModal from "../../components/SimpleAlertModal";
import Loading from "../../components/Loading";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [modalShow, setModalShow] = React.useState(false);
    const [loading, setLoading] = React.useState(false);
    let routerHistory = useHistory();

    function validateForm() {
        return email.length > 0 && password.length > 0;
    }

    async function handleSubmit(event) {
        event.preventDefault();
        routerHistory.push('/perfil');
        // setLoading(true)
        // api.post('/Auth', {
        //     email: email,
        //     password: password
        // }).then(function (response) {
        //     if (response.data.status = true) {
        //         localStorage.setItem('id', response.data.id.toString())
        //         localStorage.setItem('token', response.data.token.toString())
        //         routerHistory.push('/perfil');
        //     } else {
        //         setModalShow(true)
        //     }
        // }).catch(function (error) {
        //     setModalShow(true)
        // }).finally(function () {
        //     setLoading(false)
        // });
    }

    return (
        <div className="Container">
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

            <SimpleAlertModal
                title="Oops!"
                label="Erro ao fazer login"
                buttonText="Ok"
                show={modalShow}
                onHide={() => setModalShow(false)}
            />
            <Loading loading={loading} />
        </div>
    );
}

export default Login;
