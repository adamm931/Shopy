import { ShopyReducer } from './Reducers/ShopyReducer'
import { createStore, applyMiddleware } from 'redux'
import createSagaMiddleware from 'redux-saga'
import * as ShopySaga from './Saga/ShopySaga'
import createHistory from 'history/createBrowserHistory';
import { routerMiddleware } from 'react-router-redux';

//create history
export const shopyHistory = createHistory();

// //create saga
const sagaMiddleware = createSagaMiddleware()

// create store and bind saga
export const shopyStore = createStore(
    ShopyReducer,
    applyMiddleware(sagaMiddleware, routerMiddleware(shopyHistory)))

// run saga
sagaMiddleware.run(ShopySaga.Watch)