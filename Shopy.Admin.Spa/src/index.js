import React from 'react'
import ReactDOM from 'react-dom'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import * as serviceWorker from './serviceWorker'
import { Provider } from 'react-redux'
import { shopyStore } from './State/ShopyStore'
import { history } from './State/ShopyStore'
import { Router } from 'react-router-dom'
import Header from './Components/Header/Header'
import Body from './Components/Body/Body'

const app = (
    <Provider store={shopyStore}>
        <Router history={history}>
            <Header />
            <Body />
        </Router>
    </Provider>
)

ReactDOM.render(app, document.getElementById('root'));

serviceWorker.unregister();
