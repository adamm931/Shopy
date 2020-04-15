import { IDeleteProductRequestPayload } from './../../State/Requests/Products/IDeleteProductRequest';
import { IProductApiModel } from '../Api/IProductApiModel'
import { IProduct } from './IProduct'
import { IEditProductRequestPayload } from './../../State/Requests/Products/IEditProductRequest';
import { IAddProductRequestPayload } from './../../State/Requests/Products/IAddProductRequest';
import { Post, Get, Put, Delete } from '../Api/ShopyClient';
import { IProductListItem } from './IProductListItem';
import { IGetProductRequestPayload } from '../../State/Requests/Products/IGetPropductRequest';

export class ProductsService {

    public static AddProduct = async (product: IAddProductRequestPayload): Promise<any> =>
        await Post<any, IAddProductRequestPayload>("/products", product)

    public static EditProduct = async (product: IEditProductRequestPayload): Promise<any> =>
        await Put<any, IEditProductRequestPayload>(`/products/${product.Uuid}`, product);

    public static DeleteProduct = async (product: IDeleteProductRequestPayload): Promise<any> =>
        await Delete<any>(`/products/${product.Uid}`)

    public static ListProducts = async (): Promise<IProductListItem[]> =>
        await Get<IProductListItem[]>("/products")

    public static GetProduct = async (request: IGetProductRequestPayload): Promise<IProduct> => {
        var apiProduct = await Get<IProductApiModel>(`/products/${request.Uid}/get`)
        return {
            Uid: apiProduct.Uid,
            Name: apiProduct.Name,
            Description: apiProduct.Description,
            Price: apiProduct.Price,
            Sizes: apiProduct.Sizes.map(model => model.Name),
            Brand: apiProduct.Brand.Name
        }
    }
}