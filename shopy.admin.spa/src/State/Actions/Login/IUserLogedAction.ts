import { IBaseAction } from '../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IUserLogedAction extends IBaseAction<{}> {
    type: typeof ActionTypes.USER_LOGED_IN
}