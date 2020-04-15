import { AuthService } from './../Service/Auth/AuthService';
import { ActionTypes } from './Actions/Base/ActionTypes';
import { IActions } from './Actions/Base/Actions';
import { IShopyState, InitialState } from './ShopyState';

const authService = new AuthService();

export const ShopyReducer = (state: IShopyState = InitialState, action: IActions): IShopyState => {

    console.log('state', state)

    switch (action.type) {
        case ActionTypes.USER_LOGED_IN: {

            authService.LoginUser();
            return {
                ...state,
                IsUserLogged: true
            }
        }
        case ActionTypes.PRODUCT_LIST: {
            return {
                ...state,
                ProductList: action.Payload
            }
        }
        case ActionTypes.PRODUCT_EDIT: {
            return {
                ...state,
                EditingProduct: action.Payload
            }
        }
        case ActionTypes.PRODUCT_DELETED: {
            return {
                ...state,
                ProductList: state.ProductList.filter(product => product.Uid !== action.Payload.Uid)
            };
        }
        case ActionTypes.REDIRECT: {
            return {
                ...state,
                RedirectTo: action.Payload.Url
            }
        }
        case ActionTypes.CLEAR_REDIRECT: {
            return {
                ...state,
                RedirectTo: undefined
            }
        }
        default: {
            return state
        }
    }
}
