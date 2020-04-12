import IShopyClient from './IShopyClient'
import IApiResponse from './IApiResponse'
import axios from 'axios'
import { HttpMethod } from '../Models/Http/HttpMethod';

export async function Get<TResult>(path: string): Promise<IApiResponse<TResult>> {
    return await ShopyClient.Create().Get(path);
}

export async function Post<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>> {
    return await ShopyClient.Create().Post(path, body);
}

export async function Put<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>> {
    return await ShopyClient.Create().Put(path, body);
}

export async function Delete<TResult>(path: string): Promise<IApiResponse<TResult>> {
    return await ShopyClient.Create().Delete(path);
}

class ShopyClient implements IShopyClient {

    BaseAddress: string;

    private constructor(baseAddress: string) {
        this.BaseAddress = baseAddress;
    }

    public static Create(): IShopyClient {
        return new ShopyClient("http://localhost:50181/api");
    }

    async Get<TResult>(path: string): Promise<IApiResponse<TResult>> {
        return await this.request<TResult>(HttpMethod.Get, path);
    }

    async Post<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>> {
        return await this.request<TResult>(HttpMethod.Post, path, body);
    }

    async Put<TResult, TRequest>(path: string, body: TRequest): Promise<IApiResponse<TResult>> {
        return await this.request<TResult>(HttpMethod.Put, path, body);
    }

    async Delete<TResult>(path: string): Promise<IApiResponse<TResult>> {
        return await this.request<TResult>(HttpMethod.Delete, path);
    }

    async request<TResult, TRequest = {}>(
        method: HttpMethod,
        path: string,
        data: TRequest = {} as any): Promise<IApiResponse<TResult>> {
        try {
            const response = await this.createClient()
                .request({
                    data: data,
                    url: path,
                    method: method
                });

            return {
                Body: response.data.Result as TResult
            } as IApiResponse<TResult>;
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    }

    createClient = () => axios.create({
        baseURL: this.BaseAddress,
        headers: {
            'Content-Type': 'application/json',
        }
    })

}