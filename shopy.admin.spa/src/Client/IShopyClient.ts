import IApiResponse from './IApiResponse'

export default interface IShopyClient {
    BaseAddress: string;

    Get<TResult>(path: string): Promise<IApiResponse<TResult>>;

    Post<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>>;

    Put<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>>;

    Delete<TBody>(path: string): Promise<IApiResponse<TBody>>;
}