import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App/App'
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux';
import { shopyStore } from './State/ShopyStore';
import { shopyHistory } from './State/ShopyStore';
import { Router } from 'react-router';

const app = (
    <Provider store={shopyStore}>
        <Router history={shopyHistory}>
            <App />
        </Router>
    </Provider>
)

ReactDOM.render(app, document.getElementById('root'));

serviceWorker.unregister();
