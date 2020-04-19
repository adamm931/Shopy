import { IKeyValue } from './../../Components/Shared/Types/IKeyValue';
import { Header } from './Header';
import IShopyClient from './IShopyClient'
import axios, { AxiosRequestConfig } from 'axios'
import { HttpMethod } from './HttpMethod';

export async function Get<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Create().Get(path);
}

export async function Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Create().Post(path, body);
}

export async function PostForm<TResult>(path: string, body: FormData, headers: IKeyValue[]): Promise<TResult> {

    let client = ShopyClient.Create()

    client.AddHeader(headers)

    return await client.PostForm(path, body);
}

export async function Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Create().Put(path, body);
}

export async function PutForm<TResult>(path: string, body: FormData): Promise<TResult> {
    return await ShopyClient.Create().PutForm(path, body);
}

export async function Delete<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Create().Delete(path);
}

class ShopyClient implements IShopyClient {

    private header: Header
    private baseAddress: string

    private constructor(baseAddress: string) {
        this.baseAddress = baseAddress;
        this.header = new Header()
    }

    AddHeader(headers: IKeyValue[]): void {

        headers.forEach(header => {
            this.header.AddEntry(header.Key, header.Value)
        });

    }

    public static Create(): IShopyClient {
        return new ShopyClient(process.env.REACT_APP_API_ADDRESS as string);
    }

    async Get<TResult>(path: string): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Get, path);
    }

    async Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Post, path, body);
    }

    async PostForm<TResult>(path: string, body: FormData): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Post, path, body, true);
    }

    async Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Put, path, body);
    }

    async PutForm<TResult>(path: string, body: FormData): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Put, path, body, true);
    }

    async Delete<TResult>(path: string): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Delete, path);
    }

    async request<TResult, TRequest = {}>(
        method: HttpMethod,
        path: string,
        data: TRequest = {} as any,
        multipart?: boolean): Promise<TResult> {
        try {

            let contentType = multipart ? "multipart/form-data" : "application/json"
            this.header.AddEntry("Content-Type", contentType)

            console.log("header - raw", this.header.Raw())

            let request: AxiosRequestConfig = {
                data: data,
                url: path,
                method: method,
                headers: this.header.Raw()
            };

            const response = await this.createClient().request(request);
            return response.data.Result as TResult;
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    }

    createClient = () => axios.create({
        baseURL: this.baseAddress,
    })

}