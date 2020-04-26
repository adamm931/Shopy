import { ActionTypes } from '../Base/ActionTypes';
import { Category } from '../../../Service/Categories/Models/Category';
import { IBaseAction } from '../Base/IBaseAction';

export interface CategoryEditAction extends IBaseAction<CategoryEditActionPayload> {
    type: typeof ActionTypes.CATEGORY_EDIT
}

export interface CategoryEditActionPayload {
    Category: Category
}
