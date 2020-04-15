import { IProductDeletedAction } from './../Products/IProductDeletedAction';
import { IClearRedirectAction } from './../Redirect/IClearRedirectAction';
import { IRedirectAction } from './../Redirect/IRedirectAction';
import { IProductEditAction } from './../Products/IEditingProductAction';
import { IProductListAction } from './../Products/IProductListAction';
import { IUserLogedAction } from '../Login/IUserLogedAction';

export type IActions = IUserLogedAction
    | IProductListAction
    | IProductEditAction
    | IRedirectAction
    | IClearRedirectAction
    | IProductDeletedAction;