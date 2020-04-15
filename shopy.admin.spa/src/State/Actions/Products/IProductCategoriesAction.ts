import { INameUidApiModel } from './../../../Service/Api/INameUidApiModel';
import { IBaseAction } from './../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IGetProductCategoriesAction extends IBaseAction<IGetProductCategoriesActionPayload> {
    type: typeof ActionTypes.PRODUCT_CATEGORIES
}

export interface IGetProductCategoriesActionPayload {
    Categories: INameUidApiModel[];
}