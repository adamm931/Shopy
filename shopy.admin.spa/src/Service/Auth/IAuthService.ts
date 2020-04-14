import { IAuthenticateResponse } from './ILoginResponse';
import { AuthenticateRequest } from "./LoginRequest";

export interface IAuthService {

    AuthenticateAsync(loginRequest: AuthenticateRequest): Promise<IAuthenticateResponse>;

    IsUserLogged(): boolean;

    LoginUser(): void;

    LogoutUser(): void;
}