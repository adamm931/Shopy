import { IProduct } from '../../../Service/Products/IProduct';
import { IBaseAction } from './../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IEditingProductAction extends IBaseAction<IProduct> {
    type: typeof ActionTypes.EDITING_PRODUCT
}