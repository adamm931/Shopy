import { IBaseRequest } from './../Base/IBaseRequest';

export interface IDeleteProductRequest extends IBaseRequest<IDeleteProductRequestPayload> {
}

export interface IDeleteProductRequestPayload {
    Uid: string;
}