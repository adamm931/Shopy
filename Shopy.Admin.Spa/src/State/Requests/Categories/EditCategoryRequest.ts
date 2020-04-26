import { IBaseRequest } from './../Base/IBaseRequest';

export interface EditCategoryRequest extends IBaseRequest<EditCategoryRequestPayload> {
}

export interface EditCategoryRequestPayload {
    Uid: string;
    Name: string;
}