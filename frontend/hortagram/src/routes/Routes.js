import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";

import App from "../views/App";
import Login from "../views/login/Login";
import SignUp from "../views/signup/SignUp";
import Perfil from "../views/perfil/Perfil";
import Friends from "../views/friends/Friends";
import Logout from "../views/logout/Logout";
import Home from "../views/home/Home";

export default function Routes() {
  return (
    <Router>
      <Route exact path="/" component={App} />
      <Route exact path="/login" component={Login} />
      <Route exact path="/home" component={Home} />
      <Route path="/signup" component={SignUp} />
      <Route path="/perfil/:id" component={Perfil} />
      <Route path="/friends/:id" component={Friends} />
      <Route path="/logout" component={Logout} />
    </Router>
  );
}