import { IUserLogedAction } from './../Login/IUserLogedAction';
import { ActionTypes } from '../Base/ActionTypes';

export const UserLogedIn = (): IUserLogedAction => {
    return {
        type: ActionTypes.USER_LOGED_IN,
        Payload: {}
    }
}