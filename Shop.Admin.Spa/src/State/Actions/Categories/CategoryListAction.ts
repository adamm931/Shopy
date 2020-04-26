import { Category } from './../../../Service/Categories/Models/Category';
import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';

export interface CategoryListAction extends IBaseAction<CategoryListActionPayload> {
    type: ActionTypes.CATEGORY_LIST
}

export interface CategoryListActionPayload {
    Categories: Category[]
}