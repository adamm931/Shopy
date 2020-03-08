import { LoginUrl } from '../../Client/Urls';
import { LoginResponse } from './../../Models/Auth/LoginResponse';
import { LoginRequest } from './../../Models/Auth/LoginRequest';
import { IAuthService } from './IAuthService';
import { Post } from '../../Client/ShopyClient';

export class AuthService implements IAuthService {

    async Login(loginRequest: LoginRequest): Promise<LoginResponse> {

        var response = await Post<boolean, LoginRequest>(LoginUrl, loginRequest)

        var isSuccess = response.Body;

        return new LoginResponse(isSuccess);
    }
}