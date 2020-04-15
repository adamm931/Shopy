import { IDeleteProductRequest } from './../Products/IDeleteProductRequest';
import { IEditProductRequest } from './../Products/IEditProductRequest';
import { IGetProductRequest } from './../Products/IGetPropductRequest';
import { IProductsListRequest } from '../Products/IProductsListRequest';
import { IAddProductRequest, IAddProductRequestPayload } from './../Products/IAddProductRequest';
import { ILoginUserRequest, ILoginUserRequestPayload } from './../Login/ILoginUserRequest';
import { RequestTypes } from '../Base/RequestTypes';

export const LoginUserRequest = (username: string, password: string): ILoginUserRequest => ({
    Payload: {
        Username: username,
        Password: password
    },
    type: RequestTypes.LOGIN_USER
} as ILoginUserRequest)

export const AddProductRequest = (name: string, description: string, price: number, brand: string, sizes: string[]): IAddProductRequest => ({
    Payload: {
        Caption: name,
        Description: description,
        Price: price,
        Brand: brand,
        Sizes: sizes,
    },
    type: RequestTypes.ADD_PRODUCT
})

export const EditProductRequest = (uid: string, name: string, description: string, price: number, brand: string, sizes: string[]): IEditProductRequest => ({
    Payload: {
        Uuid: uid,
        Caption: name,
        Description: description,
        Price: price,
        Brand: brand,
        Sizes: sizes,
    },
    type: RequestTypes.EDIT_PRODUCT
})

export const DeleteProductRequest = (uid: string): IDeleteProductRequest => ({
    Payload: {
        Uid: uid
    },
    type: RequestTypes.DELETE_PRODUCT
})

export const ListProductsRequest = (): IProductsListRequest => ({
    Payload: {},
    type: RequestTypes.LIST_PRODUCTS
})

export const GetProductRequest = (uid: string): IGetProductRequest => ({
    Payload: {
        Uid: uid
    },
    type: RequestTypes.GET_PRODUCT
})