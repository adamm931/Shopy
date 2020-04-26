import { ActionTypes } from './../Base/ActionTypes';
import { INameUidApiModel } from './../../../Service/Api/INameUidApiModel';
import { IBaseAction } from './../Base/IBaseAction';

export interface ILookupCategoriesAction extends IBaseAction<ILookupCategoriesActionPayload> {
    type: typeof ActionTypes.CATEGORIES_LOOKUP
}

export interface ILookupCategoriesActionPayload {
    Lookup: INameUidApiModel[]
}