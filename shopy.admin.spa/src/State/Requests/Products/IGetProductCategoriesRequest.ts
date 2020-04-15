import { IBaseRequest } from './../Base/IBaseRequest';

export interface IGetProductCategoriesRequest extends IBaseRequest<IGetProductCategoriesRequestPayload> {
}

export interface IGetProductCategoriesRequestPayload {
    Uid: string
}