import { IBaseRequest } from './../Base/IBaseRequest';

export interface IUploadProductImageRequest extends IBaseRequest<IUploadProductImageRequestPayload> {
}

export interface IUploadProductImageRequestPayload {
    ProductUid: string
    Images: File[]
}