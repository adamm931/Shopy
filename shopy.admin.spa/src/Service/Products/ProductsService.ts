import { IProductApiModel } from '../Api/IProductApiModel'
import { IProduct } from './IProduct'
import { IEditProductRequestPayload } from './../../State/Requests/Products/IEditProductRequest';
import { IAddProductRequestPayload } from './../../State/Requests/Products/IAddProductRequest';
import { Post, Get, Put } from '../Api/ShopyClient';
import { IProductListItem } from './IProductListItem';
import { IGetProductRequestPayload } from '../../State/Requests/Products/IGetPropductRequest';

export class ProductsService {

    public static AddProduct = async (product: IAddProductRequestPayload): Promise<any> => {
        await Post<any, IAddProductRequestPayload>("/products", product)
            .catch(error => console.error(error))
    }

    public static EditProduct = async (product: IEditProductRequestPayload): Promise<any> => {
        await Put<any, IEditProductRequestPayload>(`/products/${product.Uuid}`, product)
            .catch(error => console.error(error))
    }

    public static ListProducts = async (): Promise<IProductListItem[]> => {
        var listResult = await Get<IProductListItem[]>("/products")
        return listResult
    }

    public static GetProduct = async (request: IGetProductRequestPayload): Promise<IProduct> => {
        var apiProduct = await Get<IProductApiModel>(`/products/${request.Uid}/get`)

        var result: IProduct = {
            Uid: apiProduct.Uid,
            Name: apiProduct.Name,
            Description: apiProduct.Description,
            Price: apiProduct.Price,
            Sizes: apiProduct.Sizes.map(model => model.Name),
            Brand: apiProduct.Brand.Name
        }

        console.log("client product", result)

        return result
    }
}