import { IBaseRequest } from './../Base/IBaseRequest';

export interface IGetProductRequest extends IBaseRequest<IGetProductRequestPayload> {
}

export interface IGetProductRequestPayload {
    Uid: string
}