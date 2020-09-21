import React, {useEffect, useState} from "react";
import "./Home.css";
import SimpleAlertModal from "../../components/SimpleAlertModal";
import Posts from "../../components/Posts";
import api from '../../services/api'
import Loading from "../../components/Loading";
import NavBar from "../../components/NavBar";
import { Button, Form } from "react-bootstrap";

function Home() {
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    const [list] = useState([]);
    const [imageBase64, setImageBase64] = useState("");
    const [description, setDescription] = useState("");
    const [componentIsMounted, setComponentIsMounted] = React.useState(false);
    const [loading, setLoading] = React.useState(false);

    async function getPosts() {
        setComponentIsMounted(true)
        setLoading(true)
        let id = localStorage.getItem('id');
        api.get(`/Post/feed?userId=${id}`)
        .then(function (response) {
            var responseList = response.data 
            for(const user in responseList) {
                if(responseList[user].id != id) list.push(responseList[user])
            }
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    useEffect(() => {
        if (!componentIsMounted) {
            getPosts();
        }
    });

    function validateForm() {
        return imageBase64.length > 0 && description.length > 0;
    }

    async function handleSubmit(event) {
        event.preventDefault();
        setLoading(true)
        
        const formData = new FormData();
        formData.append("UserId", localStorage.getItem('id'));
        formData.append("ImageBase64", imageBase64);
        formData.append("Description", description);
        
        api.post(`/Post?UserId=${localStorage.getItem('id')}`, formData, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`,
                "Content-Type": "multipart/form-data"
            }
        }).then(function (response) {
        }).catch(function (error) {
            setAlertModalShow(true)
        }).finally(function () {
            setLoading(false)
        });
    }

    function setImage64(blob) {
        const reader = new FileReader();
        reader.onload = function (e) {
            setImageBase64(e.target.result);
        }
        reader.readAsDataURL(blob)
    }

    return (
        <div className="Home">
            <NavBar />

            <div className="divCreatePost">
                <div className="createPost">
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId="imageBase64" bsSize="large">
                            <h3>Foto a publicar</h3>
                            <Form.Control
                                onChange={e => setImage64(e.target.files[0])}
                                type="file" 
                                accept="image/*"
                            />
                        </Form.Group>
                        <Form.Group controlId="description" bsSize="large">
                            <Form.Control
                                value={description}
                                onChange={e => setDescription(e.target.value)}
                                type="text"
                            />
                        </Form.Group>
                        <Button block bsSize="large" disabled={!validateForm()} type="submit">
                            Publicar
                        </Button>
                    </Form>
                </div>
            </div>

            <div className="posts">
                <Posts 
                    list = {list}
                    canComment={true}  
                />
            </div>

            <SimpleAlertModal
                title="Oops!"
                label="Ocorreu um erro ao carregar"
                buttonText="Ok"
                show={alertModalShow}
                onHide={() => setAlertModalShow(false)}
            />
            <Loading loading={loading} />
        </div>
    );
}

export default Home;
