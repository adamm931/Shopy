import { IBaseRequest } from './../Base/IBaseRequest';

export interface ILoginUserRequest extends IBaseRequest<ILoginUserRequestPayload> {
}

export interface ILoginUserRequestPayload {
    Username: string;
    Password: string;
}