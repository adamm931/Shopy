import { ILoginUserRequest, ILoginUserRequestPayload } from './../Login/ILoginUserRequest';
import { RequestTypes } from '../Base/RequestTypes';

export const LoginUserRequest = (username: string, password: string): ILoginUserRequest => ({
    Payload: {
        Username: username,
        Password: password
    } as ILoginUserRequestPayload,
    type: RequestTypes.LOGIN_USER
} as ILoginUserRequest) 