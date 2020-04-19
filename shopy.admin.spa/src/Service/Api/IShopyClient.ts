import { IKeyValue } from './../../Components/Shared/Types/IKeyValue';

export default interface IShopyClient {
    AddHeader(headers: IKeyValue[]): void;

    Get<TResult>(path: string): Promise<TResult>;

    Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult>;

    PostForm<TResult>(path: string, body: FormData): Promise<TResult>;

    Put<TResult, TRequest>(path: string, body: TRequest, multipart?: boolean): Promise<TResult>;

    PutForm<TResult>(path: string, body: FormData): Promise<TResult>;

    Delete<TBody>(path: string): Promise<TBody>;
}