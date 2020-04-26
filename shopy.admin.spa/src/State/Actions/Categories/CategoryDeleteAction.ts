import { ActionTypes } from '../Base/ActionTypes';
import { Category } from '../../../Service/Categories/Models/Category';
import { IBaseAction } from '../Base/IBaseAction';

export interface CategoryDeleteAction extends IBaseAction<CategoryDeleteActionPayload> {
    type: typeof ActionTypes.CATEGORY_DELETE
}

export interface CategoryDeleteActionPayload {
    Uid: string
}
