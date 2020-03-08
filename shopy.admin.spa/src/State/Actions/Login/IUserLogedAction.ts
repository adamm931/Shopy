import { IBaseAction } from '../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IUserLogedAction extends IBaseAction<IUserLogedActionPayload> {
    type: typeof ActionTypes.USER_LOGED_IN
}

export interface IUserLogedActionPayload {
    IsSuccess: boolean;
}