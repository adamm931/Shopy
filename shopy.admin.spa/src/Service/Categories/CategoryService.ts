import { INameUidApiModel } from './../Api/INameUidApiModel';
import { Get } from '../Api/ShopyClient';


export class CategoryService {
    public static Lookup = async (): Promise<INameUidApiModel[]> =>
        await Get<INameUidApiModel[]>("/categories/lookup")
}