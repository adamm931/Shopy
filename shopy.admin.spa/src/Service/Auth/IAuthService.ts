import { LoginResponse } from './../../Models/Auth/LoginResponse';
import { LoginRequest } from "../../Models/Auth/LoginRequest";

export interface IAuthService {
    Login(loginRequest: LoginRequest): Promise<LoginResponse>;
}