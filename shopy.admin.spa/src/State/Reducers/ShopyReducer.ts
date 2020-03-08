import { ActionTypes } from '../Actions/Base/ActionTypes';
import { IActions } from '../Actions/Base/Actions';
import { IShopyState, GetInitailState } from '../ShopyState';

const initialState = GetInitailState();

export const ShopyReducer = (state: IShopyState = initialState, action: IActions): IShopyState => {
    switch (action.type) {
        case ActionTypes.USER_LOGED_IN: {
            return {
                ...state,
                IsUserLogged: action.Payload.IsSuccess
            } as IShopyState
        }
    }
}
