import { ILocalStorageService } from './../Storage/ILocalStorageService';
import { LocalStorageKeys } from './../../Common/LocalStorageKeys';
import { LocalStorageService } from './../Storage/LocalStorageService';
import { LoginUrl } from '../../Client/Urls';
import { IAuthenticateResponse } from '../../Models/Auth/ILoginResponse';
import { AuthenticateRequest } from './../../Models/Auth/LoginRequest';
import { IAuthService } from './IAuthService';
import { Post } from '../../Client/ShopyClient';

export class AuthService implements IAuthService {

    private LocalStorage: ILocalStorageService = LocalStorageService.Create();

    LogoutUser(): void {
        this.LocalStorage.DeleteItem(LocalStorageKeys.UserLoggedIn);
    }

    LoginUser(): void {
        this.LocalStorage.SetItem(LocalStorageKeys.UserLoggedIn, true);
    }

    IsUserLogged(): boolean {

        if (!this.LocalStorage.HasItem(LocalStorageKeys.UserLoggedIn)) {
            return false;
        }

        return this.LocalStorage.GetItem<boolean>(LocalStorageKeys.UserLoggedIn);;
    }

    async AuthenticateAsync(loginRequest: AuthenticateRequest): Promise<IAuthenticateResponse> {

        var response = await Post<IAuthenticateResponse, AuthenticateRequest>(LoginUrl, loginRequest)

        return response.Body;
    }
}