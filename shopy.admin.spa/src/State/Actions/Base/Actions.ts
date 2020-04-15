import { IProductRemovedFromCategoryAction } from './../Products/IProductRemovedFromCategoryAction';
import { IProductAddedToCategoryAction } from '../Products/IProductAddedToCategoryAction';
import { IGetProductCategoriesAction } from './../Products/IProductCategoriesAction';
import { ILookupCategoriesAction } from './../Categories/ILookupCategoriesAction';
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
    | IProductDeletedAction
    | ILookupCategoriesAction
    | IGetProductCategoriesAction
    | IProductAddedToCategoryAction
    | IProductRemovedFromCategoryAction;