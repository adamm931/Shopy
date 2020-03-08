import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App/App'
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux';
import { ShopyStore } from './State/ShopyStore';

const app = (
    <Provider store={ShopyStore}>
        <App />
    </Provider>
)

ReactDOM.render(app, document.getElementById('root'));

serviceWorker.unregister();
