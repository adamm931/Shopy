import { ShopyReducer } from './Reducers/ShopyReducer'
import { createStore, applyMiddleware } from 'redux'
import createSagaMiddleware from 'redux-saga'
import * as ShopySaga from './Saga/ShopySaga'

// //create saga
const sagaMiddleware = createSagaMiddleware()

// create store and bind saga
export const ShopyStore = createStore(ShopyReducer, applyMiddleware(sagaMiddleware))

// run saga
sagaMiddleware.run(ShopySaga.Watch)