import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';
import { IProductListItem } from '../../../Service/Products/IProductListItem';

export interface IProductListAction extends IBaseAction<IProductListItem[]> {
    type: typeof ActionTypes.PRODUCT_LIST
}