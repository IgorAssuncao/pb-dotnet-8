import React from "react";
import { Navbar, Nav } from "react-bootstrap";

function NavBar() {
    const perfil = `http://localhost:3000/perfil/${localStorage.getItem('id')}`;
    const friends = `http://localhost:3000/friends/friends}`;

    return (
        <div class="navBar">
            <Navbar bg="dark" variant="dark">
                <Navbar.Brand href="http://localhost:3000/home">
                    <img
                        src="assets/alface.png"
                        width="30"
                        height="30"
                        className="d-inline-block align-top"
                    />{' '}
                    Home
                </Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link href={perfil} on>Perfil</Nav.Link>
                    <Nav.Link href={friends} on>Usuários</Nav.Link>
                </Nav>
                <Nav>
                    <Nav.Link href="http://localhost:3000/logout" on>Logout</Nav.Link>
                </Nav>
            </Navbar>
        </div>
    );
}

export default NavBar;