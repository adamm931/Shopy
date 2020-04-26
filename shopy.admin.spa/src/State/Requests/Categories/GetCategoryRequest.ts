import { IBaseRequest } from './../Base/IBaseRequest';

export interface GetCategoryRequest extends IBaseRequest<GetCategoryRequestPayload> {
}

export interface GetCategoryRequestPayload {
    Uid: string
}