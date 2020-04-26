import { IProduct } from '../../../Service/Products/Models/IProduct';
import { IBaseAction } from '../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IProductEditAction extends IBaseAction<IProduct> {
    type: typeof ActionTypes.PRODUCT_EDIT
}