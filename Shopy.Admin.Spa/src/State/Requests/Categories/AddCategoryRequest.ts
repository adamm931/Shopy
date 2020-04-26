import { IBaseRequest } from './../Base/IBaseRequest';

export interface AddCategoryRequest extends IBaseRequest<AddCategoryRequestPayload> {
}

export interface AddCategoryRequestPayload {
    Name: string;
}