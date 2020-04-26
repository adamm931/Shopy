import { ILoginFormState } from './ILoginFormState';

export interface ILoginFormDispatch {
    LoginUser: (state: ILoginFormState) => any
}