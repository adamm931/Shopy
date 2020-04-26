import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';
import { IProductListItem } from '../../../Service/Products/Models/IProductListItem';

export interface IProductListAction extends IBaseAction<IProductListItem[]> {
    type: typeof ActionTypes.PRODUCT_LIST
}