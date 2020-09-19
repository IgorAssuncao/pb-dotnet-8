import React from "react";
import { Spinner } from "react-bootstrap";
import "./Loading.css";

function Loading(props) {
    if(props.loading == true){
        return (
            <div class="loading-container">
                <div className="loader">
                    <Spinner animation="border" />
                </div>
            </div>
        );
    } else return null
}

export default Loading;