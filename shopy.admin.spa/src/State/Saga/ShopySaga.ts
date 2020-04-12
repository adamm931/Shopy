import { AuthenticateRequest } from './../../Models/Auth/LoginRequest';
import { RequestTypes } from '../Requests/Base/RequestTypes';
import { ILoginUserRequest } from './../Requests/Login/ILoginUserRequest';
import { all, put, takeLatest, call } from 'redux-saga/effects'
import { AuthService } from '../../Service/Auth/AuthService';
import * as ActionFactory from '../Actions/Factory/ActionFactory';
import { IAuthenticateResponse } from '../../Models/Auth/ILoginResponse';

function* WatchLoginUser() {
    yield takeLatest(RequestTypes.LOGIN_USER, LoginUser)
}

function* WatchLogoutUser() {
    yield takeLatest(RequestTypes.LOGOUT_USER, LogoutUser)
}

function LogoutUser() {
    var authService = new AuthService();
    authService.LogoutUser();
}

function* LoginUser(request: ILoginUserRequest) {

    var authService = new AuthService();
    var payload = request.Payload;
    var loginRequest = new AuthenticateRequest(payload.Username, payload.Password);

    var authenticateResponse: IAuthenticateResponse = yield call(() => authService.AuthenticateAsync(loginRequest));

    if (authenticateResponse.IsAuthenticated) {
        yield put(ActionFactory.UserLogedIn());
    }
}

export function* Watch() {
    yield all([
        WatchLoginUser(),
        WatchLogoutUser()
    ])
}