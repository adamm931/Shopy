import { ActionTypes } from '../Base/ActionTypes';
import { IBaseAction } from '../Base/IBaseAction';

export interface IProductRemovedFromCategoryAction extends IBaseAction<IProductRemovedFromCategoryActionPayload> {
    type: typeof ActionTypes.PRODUCT_REMOVED_FROM_CATEGORY
}

export interface IProductRemovedFromCategoryActionPayload {
    ProductUid: string;
    CategoryUid: string;
}