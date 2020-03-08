import { IAction } from "./IActions";

export interface IBaseAction<TPayload> extends IAction {
    Payload: TPayload
}