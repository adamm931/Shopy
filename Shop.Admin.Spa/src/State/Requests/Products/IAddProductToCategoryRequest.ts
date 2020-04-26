import { IBaseRequest } from './../Base/IBaseRequest';

export interface IAddProductToCategoryRequest extends IBaseRequest<IAddProductToCategoryRequestPayload> {
}

export interface IAddProductToCategoryRequestPayload {
    ProductUid: string
    CategoryUid: string
}