import React, {useEffect, useState} from "react";
import { Col, Image, Row, Button } from "react-bootstrap";
import "./Perfil.css";
import SimpleInputModal from "../../components/SimpleInputModal";
import SimpleAlertModal from "../../components/SimpleAlertModal";
import api from '../../services/api'
import Loading from "../../components/Loading";
import PerfilPosts from "../../components/PerfilPosts";

function Perfil() {
    const [editPefilModalShow, setEditPefilModalShow] = React.useState(false);
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    const [name, setName] = useState("");
    const [componentIsMounted, setComponentIsMounted] = React.useState(false);
    const [loading, setLoading] = React.useState(false);

    async function getUser() {
        setComponentIsMounted(true)
        setLoading(true)
        const id = localStorage.getItem('id');
        api.get(`/User/${id}`)
        .then(function (response) {
            setName("Marlon")
            getPosts()
        }).catch(function (error) {
            setAlertModalShow(true)
            setLoading(false)
        }); 
    }
    
    async function getPosts() {
        setComponentIsMounted(true)
        const id = localStorage.getItem('id');
        api.get(`/Posts/${id}`)
        .then(function (response) {
            setName("Marlon")
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        }); 
    }

    useEffect(() => {
        if (!componentIsMounted) {
            getUser();
        }
    });

    return (
        <div className="Perfil">
            <div className="infoMaster">
                <Image className="perfilPhoto" src="assets/quadrado_preto.png" roundedCircle />
                <div className="info">
                    <div className="infoUsername">
                        <h4>meu usuário {name}</h4>
                        <Button variant="outline-primary" size="sm" onClick={() => setEditPefilModalShow(true)}>
                            Editar Usuário
                        </Button>
                    </div>
                    <Row>
                        <Col xs={4} md={3}>
                            <p><b>1000</b> Publicações</p>
                        </Col>
                        <Col xs={4} md={3}>
                            <p><b>1000</b> Seguidores</p>
                        </Col>
                        <Col xs={4} md={3}>
                            <p><b>1000</b> Seguindo</p>
                        </Col>
                    </Row>
                </div>
            </div>

            <hr />

            <div className="posts">
                <PerfilPosts />
            </div>

            <SimpleInputModal
                title="Editar Usuário"
                label="Usuário"
                placeholder="meuUsuário"
                buttonText="Atualizar"
                show={editPefilModalShow}
                onHide={() => setEditPefilModalShow(false)}
            />

            <SimpleAlertModal
                title="Oops!"
                label="Ocorreu um erro ao carregar suas informações"
                buttonText="Ok"
                show={alertModalShow}
                onHide={() => setAlertModalShow(false)}
            />
            <Loading loading={loading} />
        </div>
    );
}

export default Perfil;
