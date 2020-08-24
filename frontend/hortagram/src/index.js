import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import * as serviceWorker from './serviceWorker';
import Routes from './routes/Routes';

ReactDOM.render(<Routes />, document.getElementById('root'));

serviceWorker.unregister();
