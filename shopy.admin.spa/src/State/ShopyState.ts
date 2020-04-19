import { INameUidApiModel } from './../Service/Api/INameUidApiModel';
import { AuthService } from './../Service/Auth/AuthService';
import { IProduct } from '../Service/Products/Models/IProduct';
import { IProductListItem } from '../Service/Products/Models/IProductListItem';

export interface IShopyState {
    IsUserLogged: boolean
    ProductList: IProductListItem[]
    EditingProduct: IProduct
    RedirectTo?: string
    ProductCategories: INameUidApiModel[],
    AvailableProductCategories: INameUidApiModel[],
    LookupCategories: INameUidApiModel[]
}

export const EmptyEditingProduct = (): IProduct => ({
    Uid: '',
    Name: '',
    Description: '',
    Price: 0,
    Brand: '',
    Sizes: []
})

export const InitialState: IShopyState = {
    IsUserLogged: new AuthService().IsUserLogged(),
    ProductList: [],
    EditingProduct: EmptyEditingProduct(),
    ProductCategories: [],
    AvailableProductCategories: [],
    LookupCategories: []
};

