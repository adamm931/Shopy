import { IAction } from './../../Actions/Base/IActions';
export interface IBaseRequest<TPayload> extends IAction {
    Payload: TPayload
}