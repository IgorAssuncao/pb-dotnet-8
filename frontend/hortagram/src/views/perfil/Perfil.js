import React, {useEffect, useState} from "react";
import { Col, Image, Row, Button } from "react-bootstrap";
import "./Perfil.css";
import SimpleInputModal from "../../components/SimpleInputModal";
import SimpleAlertModal from "../../components/SimpleAlertModal";
import api from '../../services/api'

function Perfil() {
    const [editPefilModalShow, setEditPefilModalShow] = React.useState(false);
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    const [name, setName] = useState("");

    async function getUser() {
        const id = localStorage.getItem('id');
        api.get(`/User/${id}`)
        .then(function (response) {
            setName("Marlon")
        }).catch(function (error) {
            setAlertModalShow(true)
        }); 
    }
    
    useEffect(() => {
        getUser();
    });

    return (
        <div className="Perfil">
            <div className="infoMaster">
                <Image className="perfilPhoto" src="assets/quadrado_preto.png" roundedCircle />
                <div className="info">
                    <div className="infoUsername">
                        <h4>{name}</h4>
                        <Button variant="outline-primary" size="sm" onClick={() => setEditPefilModalShow(true)}>
                            Editar Usuário
                        </Button>
                    </div>
                    <Row>
                        <Col xs={4} md={3}>
                            <p><b>0</b> Publicações</p>
                        </Col>
                        <Col xs={4} md={3}>
                            <p><b>0</b> Seguidores</p>
                        </Col>
                        <Col xs={4} md={3}>
                            <p><b>0</b> Seguindo</p>
                        </Col>
                    </Row>
                </div>
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
        </div>
    );
}

export default Perfil;
