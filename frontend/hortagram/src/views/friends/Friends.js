import React, {useEffect, useState} from "react";
import "./Friends.css";
import SimpleAlertModal from "../../components/SimpleAlertModal";
import api from '../../services/api'
import Loading from "../../components/Loading";
import FriendList from "../../components/FriendList";
import NavBar from "../../components/NavBar";
import { useParams } from "react-router-dom";

function Friends() {
    const [alertModalShow, setAlertModalShow] = React.useState(false);
    const [list, setList] = useState([]);
    const [myFollowers, setMyFollowers] = useState([]);
    const [componentIsMounted, setComponentIsMounted] = React.useState(false);
    const [loading, setLoading] = React.useState(false);
    let { id } = useParams();

    async function getUsers() {
        setComponentIsMounted(true)
        setLoading(true)
        let myId = localStorage.getItem('id');
        if(id == myId) {
            setList(JSON.parse(localStorage.getItem('myFollowers') || '[]'));
            setLoading(false)
        } else {
            api.get(`/User`)
            .then(function (response) {
                var responseList = response.data 
                for(const user in responseList) {
                    if(responseList[user].id != myId) list.push(responseList[user])
                }
            }).catch(function (error) {
                setAlertModalShow(true)
            }).finally(function () {
                setLoading(false)
            });
        }
    }

    useEffect(() => {
        if (!componentIsMounted) {
            getUsers();
        }
    });

    return (
        <div className="Friends">
            <NavBar />
            <div className="friendList">
                <FriendList 
                    list={list}
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

export default Friends;
