import React, {useEffect, useState} from "react";
import { Col, Image, Row, Button } from "react-bootstrap";
import "./Perfil.css";
import SimpleInputModal from "../../components/SimpleInputModal";
import SimpleAlertModal from "../../components/SimpleAlertModal";
import api from '../../services/api'
import Loading from "../../components/Loading";
import PerfilPosts from "../../components/PerfilPosts";
import NavBar from "../../components/NavBar";
import { useParams } from "react-router-dom";
import { useHistory } from "react-router-dom";
  

function Perfil() {
    const [editPefilModalShow, setEditPefilModalShow] = React.useState(false);
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    const [user, setUser] = useState("");
    const [isFollowed, setIsFollowed] = React.useState(false);
    const [isFollowedText, setIsFollowedText] = useState("");
    const [followers, setFollowers] = useState([]);
    const [posts, setPosts] = useState([]);
    const [componentIsMounted, setComponentIsMounted] = React.useState(false);
    const [loading, setLoading] = React.useState(false);
    let { id } = useParams();
    let routerHistory = useHistory();

    async function getUser() {
        setComponentIsMounted(true)
        setLoading(true)
        api.get(`/User/${id}`)
        .then(function (response) {
            setUser(response.data)
            getPosts()
            if(id == localStorage.getItem('id')) {
                getMyFollowers(false)
            } else {
                getFollowers()
            }
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    async function getPosts() {
        setComponentIsMounted(true)
        setLoading(true)
        api.get(`/Post?userId=${id}`)
        .then(function (response) {
            let responseList = []
            for(const user in response.data ) {
                responseList.push(response.data[user])
            }
            setPosts(responseList)
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    async function getMyFollowers(isReload) {
        setComponentIsMounted(true)
        setLoading(true)
        api.get(`/User/${localStorage.getItem('id')}/followers`)
        .then(function (response) {
            var responseList = response.data 
            const myFollowers = [];
            const myIdsFollowers = [];
            
            for(const user in responseList) {
                myIdsFollowers.push(responseList[user].id)
                myFollowers.push(responseList[user])
            }
            setFollowers(myFollowers)
            
            localStorage.setItem("myIdsFollowers", JSON.stringify(myIdsFollowers))
            localStorage.setItem("myFollowers", JSON.stringify(myFollowers))
            
            if(isReload) window.location.reload(true);
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    async function getFollowers() {
        setComponentIsMounted(true)
        setLoading(true)
        api.get(`/User/${id}/followers`)
        .then(function (response) {
            var responseList = response.data 
            for(const user in responseList) {
                if(responseList[user].id != id) followers.push(responseList[user])
            }
            const myIdsFollowers = JSON.parse(localStorage.getItem('myIdsFollowers') || '[]');
            if(myIdsFollowers.includes(id)) {
                setIsFollowed(true)
                setIsFollowedText("Deixar de seguir")
            } else {
                setIsFollowed(false)
                setIsFollowedText("Seguir")
            }
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }
    
    async function putFollower() {
        setComponentIsMounted(true)
        setLoading(true)
        if (isFollowed) {
            api.put(`/User/${localStorage.getItem('id')}/followers`, { //deleted
                "id": id
            }).then(function (response) {
                getMyFollowers(true)
            }).catch(function (error) {
                setAlertModalShow(true)
            }).finally(function () {
                setLoading(false)
            });
        } else {
            api.post(`/User/${localStorage.getItem('id')}/followers`, { //addiction
                "id": id
            }).then(function (response) {
                getMyFollowers(true)
            }).catch(function (error) {
                setAlertModalShow(true)
            }).finally(function () {
                setLoading(false)
            }); 
        }
    }

    useEffect(() => {
        if (!componentIsMounted) {
            getUser();
        }
    });

    let headerUser = id == localStorage.getItem('id') ?
        <Row>
            <Col xs={4} md={3}>
                <p><b>{posts.length}</b> Publicações</p>
            </Col>
            <Col xs={4} md={3} />
            <Col xs={4} md={3} onClick={() => routerHistory.push(`/friends/${id}`)}>
                <p><b>{followers.length}</b> Seguindo</p>
            </Col>
        </Row>
                            
    : <Row> <Button onClick={() => putFollower()}>{isFollowedText}</Button> </Row>   

    let buttonUser = id == localStorage.getItem('id') ?
        <Button variant="outline-primary" size="sm" onClick={() => setEditPefilModalShow(true)}>
            Editar Usuário
        </Button>
    : ""


    return (
        
        <div className="Perfil">
            <NavBar />

            <div className="infoMaster">
                <Image className="perfilPhoto" src={user.photoURL} roundedCircle />
                <div className="info">
                    <div className="infoUsername">
                        <h4>{user.firstName} {user.lastname}</h4>
                        {buttonUser}
                    </div>
                    {headerUser}
                </div>
            </div>

            <hr />

            <div className="posts">
                <PerfilPosts 
                    posts={posts}    
                />
            </div>

            <SimpleInputModal
                title="Editar Usuário"
                firstName="Nome"
                lastname="Sobrenome"
                buttonText="Atualizar"
                user={user}
                show={editPefilModalShow}
                onHide={() => {
                    setComponentIsMounted(false)
                    setEditPefilModalShow(false)
                }}
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
