import { IBaseRequest } from './../Base/IBaseRequest';

export interface DeleteCategoryRequest extends IBaseRequest<DeleteCategoryRequestPayload> {
}

export interface DeleteCategoryRequestPayload {
    Uid: string
}