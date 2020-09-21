import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./SignUp.css";
import { useHistory } from "react-router-dom";
import api from '../../services/api'
import SimpleAlertModal from "../../components/SimpleAlertModal";
import Loading from "../../components/Loading";

function SignUp() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [image, setImage] = useState("");
    const [imageBase64, setImageBase64] = useState("");
    const [modalShow, setModalShow] = React.useState(false);
    const [loading, setLoading] = React.useState(false);
    let routerHistory = useHistory();

    function validateForm() {
        return email.length > 0 && password.length > 0
            && firstName.length > 0 && lastName.length > 0
            && imageBase64.length > 0;
    }

    function setImage64(blob) {
        const reader = new FileReader();
        reader.onload = function (e) {
            setImageBase64(e.target.result);
        }
        reader.readAsDataURL(blob)
    }

    async function handleSubmit(event) {
        event.preventDefault();
        setLoading(true)
        
        const formData = new FormData();
        formData.append("FirstName", firstName);
        formData.append("Lastname", lastName);
        formData.append("Email", email);
        formData.append("Password", password);
        formData.append("ImageBase64", imageBase64);
        
        api.post('/User', formData, {
            headers: {"Content-Type": "multipart/form-data"}
        }).then(function (response) {
            routerHistory.push('/login')
        }).catch(function (error) {
            setModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    return (
        <div className="SignUp">
            <Form onSubmit={handleSubmit} enctype="multipart/form-data">
                <Form.Group controlId="firstName" bsSize="large">
                    <Form.Label>Nome</Form.Label>
                    <Form.Control
                        autoFocus
                        type="text"
                        placeholder="Nome"
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group controlId="lastName" bsSize="large">
                    <Form.Label>Último Nome</Form.Label>
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
                <Form.Group controlId="image" bsSize="large">
                    <Form.Label>Foto de Perfil</Form.Label>
                    <Form.Control
                        onChange={e => setImage64(e.target.files[0])}
                        type="file" 
                        accept="image/*"
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
            <Loading loading={loading} />
        </div>
    );
}

export default SignUp;
