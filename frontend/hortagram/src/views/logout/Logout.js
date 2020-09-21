import React, {useEffect} from "react";
import { useHistory } from "react-router-dom";

function Logout() {
    const [componentIsMounted, setComponentIsMounted] = React.useState(false);
    let routerHistory = useHistory();
    
    async function logout() {
        setComponentIsMounted(true)
        localStorage.clear();
        routerHistory.push('/login');
    }

    useEffect(() => {
        if (!componentIsMounted) {
            logout();
        }
    });

    return (
        <div className="Logout">
            <h1>Logout</h1>
        </div>
    );
}

export default Logout;
