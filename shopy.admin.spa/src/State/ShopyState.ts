import { AuthService } from './../Service/Auth/AuthService';
import { IProduct } from '../Service/Products/IProduct';
import { IProductListItem } from '../Service/Products/IProductListItem';

export interface IShopyState {
    IsUserLogged: boolean;
    ProductList: IProductListItem[];
    EditingProduct: IProduct;
    RedirectTo?: string;
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
};

