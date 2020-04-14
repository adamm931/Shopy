import { ShopyReducer } from './ShopyReducer'
import { createStore, applyMiddleware } from 'redux'
import createSagaMiddleware from 'redux-saga'
import * as ShopySaga from './ShopySaga'
import { routerMiddleware } from 'react-router-redux';
import { createBrowserHistory } from 'history';

//create router history
export const history = createBrowserHistory()

// //create saga
const sagaMiddleware = createSagaMiddleware()

// create store and bind saga
export const shopyStore = createStore(
    ShopyReducer,
    applyMiddleware(sagaMiddleware, routerMiddleware(history)))

// run saga
sagaMiddleware.run(ShopySaga.Watch)