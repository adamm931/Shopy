import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';

export interface IProductDeletedAction extends IBaseAction<IProductDeleteActionPayload> {
    type: typeof ActionTypes.PRODUCT_DELETED
}

export interface IProductDeleteActionPayload {
    Uid: string;
}