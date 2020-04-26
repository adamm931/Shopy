import { DeleteCategoryRequest, DeleteCategoryRequestPayload } from './../../State/Requests/Categories/DeleteCategoryRequest';
import { GetCategoryRequestPayload } from './../../State/Requests/Categories/GetCategoryRequest';
import { Category } from './Models/Category';
import { EditCategoryRequestPayload } from './../../State/Requests/Categories/EditCategoryRequest';
import { AddCategoryRequestPayload } from './../../State/Requests/Categories/AddCategoryRequest';
import { INameUidApiModel } from './../Api/INameUidApiModel';
import { Get, Post, Put, Delete } from '../Api/ShopyClient';

export class CategoryService {
    public static Lookup = async (): Promise<INameUidApiModel[]> =>
        await Get<INameUidApiModel[]>("/categories/lookup")

    public static Add = async (data: AddCategoryRequestPayload): Promise<{}> =>
        await Post<{}, AddCategoryRequestPayload>("/categories/add", data)

    public static Edit = async (data: EditCategoryRequestPayload): Promise<{}> =>
        await Put<{}, AddCategoryRequestPayload>(`/categories/${data.Uid}/edit`, data)

    public static Get = async (data: GetCategoryRequestPayload): Promise<{}> =>
        await Get<Category>(`/categories/${data.Uid}/get`)

    public static Delete = async (data: DeleteCategoryRequestPayload): Promise<{}> =>
        await Delete<{}>(`/categories/${data.Uid}/delete`)

    // TODO: create new endpoint 
    public static List = async (): Promise<Category[]> =>
        await Get<Category[]>("/categories/lookup");
}