import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';
export interface IClearRedirectAction extends IBaseAction<{}> {
    type: typeof ActionTypes.CLEAR_REDIRECT
}