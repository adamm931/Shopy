import { IUserLogedAction } from './../Login/IUserLogedAction';
import { ActionTypes } from '../Base/ActionTypes';

export const UserLogin = (isSuccess: boolean): IUserLogedAction => {
    return {
        type: ActionTypes.USER_LOGED_IN
    } as IUserLogedAction
}