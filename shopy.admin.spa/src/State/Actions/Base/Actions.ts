import { IEditingProductAction } from './../Products/IEditingProductAction';
import { IProductListAction } from './../Products/IProductListAction';
import { IUserLogedAction } from '../Login/IUserLogedAction';

export type IActions = IUserLogedAction
    | IProductListAction
    | IEditingProductAction;