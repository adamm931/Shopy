import { IProductDeletedAction } from './../Products/IProductDeletedAction';
import { IClearRedirectAction } from './../Redirect/IClearRedirectAction';
import { IRedirectAction } from './../Redirect/IRedirectAction';
import { IProductEditAction } from './../Products/IEditingProductAction';
import { IProduct } from '../../../Service/Products/IProduct'
import { IProductListItem } from '../../../Service/Products/IProductListItem';
import { IUserLogedAction } from './../Login/IUserLogedAction';
import { ActionTypes } from '../Base/ActionTypes';
import { IProductListAction } from '../Products/IProductListAction';

export const UserLogedIn = (): IUserLogedAction => ({
    type: ActionTypes.USER_LOGED_IN,
    Payload: {}
})

export const ProductList = (products: IProductListItem[]): IProductListAction => ({
    type: ActionTypes.PRODUCT_LIST,
    Payload: products
})

export const ProductEdit = (product: IProduct): IProductEditAction => ({
    type: ActionTypes.PRODUCT_EDIT,
    Payload: product
})

export const ProductDeleted = (uid: string): IProductDeletedAction => ({
    type: ActionTypes.PRODUCT_DELETED,
    Payload: {
        Uid: uid
    }
})

export const Redirect = (url: string): IRedirectAction => ({
    type: ActionTypes.REDIRECT,
    Payload: {
        Url: url
    }
})

export const ClearRedirect = (): IClearRedirectAction => ({
    type: ActionTypes.CLEAR_REDIRECT,
    Payload: {}
})