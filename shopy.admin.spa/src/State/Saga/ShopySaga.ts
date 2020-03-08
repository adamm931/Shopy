import { LoginRequest } from './../../Models/Auth/LoginRequest';
import { RequestTypes } from '../Requests/Base/RequestTypes';
import { ILoginUserRequest } from './../Requests/Login/ILoginUserRequest';
import { all, put, takeLatest, call } from 'redux-saga/effects'
import { AuthService } from '../../Service/Auth/AuthService';
import * as ActionFactory from '../Actions/Factory/ActionFactory';

// login user
function* WatchLoginUser() {
    yield takeLatest(RequestTypes.LOGIN_USER, LoginUser)
}

function* LoginUser(request: ILoginUserRequest) {

    console.log('saga', request);

    var authService = new AuthService();
    var payload = request.Payload;
    var loginRequest = new LoginRequest(payload.Username, payload.Password);
    var loginResponse = yield call(() => authService.Login(loginRequest));

    yield put(ActionFactory.UserLogin(loginResponse.IsSuccess));
}

export function* Watch() {
    yield all([
        WatchLoginUser()
    ])
}