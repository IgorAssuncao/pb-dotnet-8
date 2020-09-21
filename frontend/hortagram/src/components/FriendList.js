import React from "react";
import { Row, Col, Image } from "react-bootstrap";
import "./FriendList.css";
import { useHistory } from "react-router-dom";

function FriendList(props) {
    let routerHistory = useHistory();

    if (props.list.length > 0) {
        const cards = []
        for (let info of props.list) {
            cards.push(
                <Col onClick={() =>  routerHistory.push(`/perfil/${info.id}`)}>
                    <div className="infoFriend">
                        <Image className="image" variant="top" src={info.photoURL} />
                        <h3>{info.firstName + " " + info.lastname}</h3>
                    </div>
                </Col> 
            )
        }
        return (
            <div>
                <Row>
                    {cards}
                </Row>
            </div>
        );
    } else {
        return (
            <div>
                <h1>Erro ao carregar usuários</h1>
            </div>
        );
    }
}

export default FriendList;