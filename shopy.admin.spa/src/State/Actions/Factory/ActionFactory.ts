import { IEditingProductAction } from './../Products/IEditingProductAction';
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

export const EditingProduct = (product: IProduct): IEditingProductAction => ({
    type: ActionTypes.EDITING_PRODUCT,
    Payload: product
})