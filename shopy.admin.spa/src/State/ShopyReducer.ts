import { AuthService } from './../Service/Auth/AuthService';
import { ActionTypes } from './Actions/Base/ActionTypes';
import { IActions } from './Actions/Base/Actions';
import { IShopyState, InitialState } from './ShopyState';

const authService = new AuthService();

export const ShopyReducer = (state: IShopyState = InitialState, action: IActions): IShopyState => {
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
        case ActionTypes.EDITING_PRODUCT: {
            return {
                ...state,
                EditingProduct: action.Payload
            }
        }
    }
}
