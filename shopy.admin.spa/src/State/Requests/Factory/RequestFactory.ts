import { IGetProductCategoriesRequest } from './../Products/IGetProductCategoriesRequest';
import { IRemoveProductFromCategoryRequest } from './../Products/IRemoveProductFromCategoryRequest';
import { IAddProductToCategoryRequest } from './../Products/IAddProductToCategoryRequest';
import { IDeleteProductRequest } from './../Products/IDeleteProductRequest';
import { IEditProductRequest } from './../Products/IEditProductRequest';
import { IGetProductRequest } from './../Products/IGetPropductRequest';
import { IProductsListRequest } from '../Products/IProductsListRequest';
import { IAddProductRequest } from './../Products/IAddProductRequest';
import { ILoginUserRequest } from './../Login/ILoginUserRequest';
import { RequestTypes } from '../Base/RequestTypes';
import { ILookupCategoriesRequest } from './../Categories/ILookupCategoriesRequest'

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

export const AddProductToCategory = (productUid: string, categoryUid: string): IAddProductToCategoryRequest => ({
    Payload: {
        ProductUid: productUid,
        CategoryUid: categoryUid
    },
    type: RequestTypes.ADD_PRODUCT_TO_CATEGORY
})

export const RemoveProductFromCategory = (productUid: string, categoryUid: string): IRemoveProductFromCategoryRequest => ({
    Payload: {
        ProductUid: productUid,
        CategoryUid: categoryUid
    },
    type: RequestTypes.REMOVE_PRODUCT_FROM_CATEGORY
})

export const GetProductCategories = (productUid: string): IGetProductCategoriesRequest => ({
    Payload: {
        Uid: productUid
    },
    type: RequestTypes.GET_PRODUCT_CATEGORIES
})

export const LookupCategories = (): ILookupCategoriesRequest => ({
    Payload: {},
    type: RequestTypes.LOOKUP_CATEGORIES
})