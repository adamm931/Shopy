import { CategoryDeleteAction } from './../Categories/CategoryDeleteAction';
import { CategoryEditAction } from './../Categories/CategoryEditAction';
import { CategoryListAction } from './../Categories/CategoryListAction';
import { Category } from './../../../Service/Categories/Models/Category';
import { IProductRemovedFromCategoryAction } from './../Products/IProductRemovedFromCategoryAction';
import { IProductAddedToCategoryAction } from './../Products/IProductAddedToCategoryAction';
import { ILookupCategoriesAction } from './../Categories/ILookupCategoriesAction';
import { IGetProductCategoriesAction } from './../Products/IProductCategoriesAction';
import { INameUidApiModel } from './../../../Service/Api/INameUidApiModel';
import { IProductDeletedAction } from './../Products/IProductDeletedAction';
import { IClearRedirectAction } from './../Redirect/IClearRedirectAction';
import { IRedirectAction } from './../Redirect/IRedirectAction';
import { IProductEditAction } from '../Products/IProductEditAction';
import { IProduct } from '../../../Service/Products/Models/IProduct'
import { IProductListItem } from '../../../Service/Products/Models/IProductListItem';
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

export const ProductCategories = (data: INameUidApiModel[]): IGetProductCategoriesAction => ({
    type: ActionTypes.PRODUCT_CATEGORIES,
    Payload: {
        Categories: data
    }
})

export const LookupCategories = (data: INameUidApiModel[]): ILookupCategoriesAction => ({
    type: ActionTypes.CATEGORIES_LOOKUP,
    Payload: {
        Lookup: data
    }
})

export const ProductAddedToCategory = (productUid: string, categoryUid: string): IProductAddedToCategoryAction => ({
    type: ActionTypes.PRODUCT_ADDED_TO_CATEGORY,
    Payload: {
        ProductUid: productUid,
        CategoryUid: categoryUid
    }
})

export const ProductRemovedFromCategory = (productUid: string, categoryUid: string): IProductRemovedFromCategoryAction => ({
    type: ActionTypes.PRODUCT_REMOVED_FROM_CATEGORY,
    Payload: {
        ProductUid: productUid,
        CategoryUid: categoryUid
    }
})

export const CategoryList = (categories: Category[]): CategoryListAction => ({
    type: ActionTypes.CATEGORY_LIST,
    Payload: {
        Categories: categories
    }
})

export const CategoryEdit = (category: Category): CategoryEditAction => ({
    type: ActionTypes.CATEGORY_EDIT,
    Payload: {
        Category: category
    }
})

export const CategoryDelete = (uid: string): CategoryDeleteAction => ({
    type: ActionTypes.CATEGORY_DELETE,
    Payload: {
        Uid: uid
    }
})