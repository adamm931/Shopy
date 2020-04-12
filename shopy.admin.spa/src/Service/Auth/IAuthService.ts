import { IAuthenticateResponse } from '../../Models/Auth/ILoginResponse';
import { AuthenticateRequest } from "../../Models/Auth/LoginRequest";

export interface IAuthService {

    AuthenticateAsync(loginRequest: AuthenticateRequest): Promise<IAuthenticateResponse>;

    IsUserLogged(): boolean;

    LoginUser(): void;

    LogoutUser(): void;
}