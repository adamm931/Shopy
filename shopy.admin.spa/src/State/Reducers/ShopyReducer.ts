import { AuthService } from './../../Service/Auth/AuthService';
import { ActionTypes } from '../Actions/Base/ActionTypes';
import { IActions } from '../Actions/Base/Actions';
import { IShopyState } from '../ShopyState';

const authService = new AuthService();

const initialState = {
    IsUserLogged: authService.IsUserLogged()
};

export const ShopyReducer = (state: IShopyState = initialState, action: IActions): IShopyState => {

    console.log('ShopyReducer - state', state);

    switch (action.type) {
        case ActionTypes.USER_LOGED_IN: {
            authService.LoginUser();
            return {
                ...state,
                IsUserLogged: true
            }
        }
    }
}
