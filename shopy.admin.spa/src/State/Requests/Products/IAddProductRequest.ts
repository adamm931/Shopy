import { IBaseRequest } from './../Base/IBaseRequest';
import { RequestTypes } from '../Base/RequestTypes';

export interface IAddProductRequest extends IBaseRequest<IAddProductRequestPayload> {
}

export interface IAddProductRequestPayload {
    Caption: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
}