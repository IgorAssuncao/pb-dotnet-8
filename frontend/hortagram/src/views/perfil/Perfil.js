import React from "react";
import { Col, Image, Row, Button } from "react-bootstrap";
import "./Perfil.css";
import SimpleInputModal from "../../components/SimpleInputModal";

function Perfil() {
    const [modalShow, setModalShow] = React.useState(false);

    return (
        <div className="Perfil">
            <div className="infoMaster">
                <Image className="perfilPhoto" src="assets/quadrado_preto.png" roundedCircle />
                <div className="info">
                    <div className="infoUsername">
                        <h4>meuUsuário</h4>
                        <Button variant="outline-primary" size="sm" onClick={() => setModalShow(true)}>
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
                show={modalShow}
                onHide={() => setModalShow(false)}
            />
        </div>
    );
}

export default Perfil;
