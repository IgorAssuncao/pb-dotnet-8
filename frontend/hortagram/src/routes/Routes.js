import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";

import App from "../views/App";
import Login from "../views/login/Login";
import SignUp from "../views/signup/SignUp";
import Perfil from "../views/perfil/Perfil";

export default function Routes() {
  return (
    <Router>
      <Route exact path="/" component={App} />
      <Route exact path="/login" component={Login} />
      <Route path="/signup" component={SignUp} />
      <Route path="/perfil" component={Perfil} />
    </Router>
  );
}