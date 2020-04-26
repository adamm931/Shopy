import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';

export interface IRedirectAction extends IBaseAction<IRedirectActionPayload> {
    type: typeof ActionTypes.REDIRECT,
}

export interface IRedirectActionPayload {
    Url: string;
}