import { ActionTypes } from '../Base/ActionTypes';
import { IBaseAction } from '../Base/IBaseAction';

export interface IProductAddedToCategoryAction extends IBaseAction<IProductAddedToCategoryActionPayload> {
    type: typeof ActionTypes.PRODUCT_ADDED_TO_CATEGORY
}

export interface IProductAddedToCategoryActionPayload {
    ProductUid: string;
    CategoryUid: string;
}