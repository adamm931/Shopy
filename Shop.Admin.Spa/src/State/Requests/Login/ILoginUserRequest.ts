import { IBaseRequest } from './../Base/IBaseRequest';
import { RequestTypes } from '../Base/RequestTypes';

export interface ILoginUserRequest extends IBaseRequest<ILoginUserRequestPayload> {
}

export interface ILoginUserRequestPayload {
    Username: string;
    Password: string;
}