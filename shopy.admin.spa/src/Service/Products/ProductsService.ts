import { IProductApiModel } from './Models/IProductApiModel';
import { IRemoveProductFromCategoryRequestPayload } from './../../State/Requests/Products/IRemoveProductFromCategoryRequest';
import { IAddProductToCategoryRequestPayload } from './../../State/Requests/Products/IAddProductToCategoryRequest';
import { INameUidApiModel } from './../Api/INameUidApiModel';
import { IDeleteProductRequestPayload } from './../../State/Requests/Products/IDeleteProductRequest';
import { IProduct } from './Models/IProduct'
import { IEditProductRequestPayload } from './../../State/Requests/Products/IEditProductRequest';
import { IAddProductRequestPayload } from './../../State/Requests/Products/IAddProductRequest';
import { Post, Get, Put, Delete } from '../Api/ShopyClient';
import { IProductListItem } from './Models/IProductListItem';
import { IGetProductRequestPayload } from '../../State/Requests/Products/IGetPropductRequest';
import { FileService } from '../Files/FileService';

export class ProductsService {

    public static AddProduct = async (product: IAddProductRequestPayload): Promise<any> =>
        await Post<any, IAddProductRequestPayload>("/products/add", product)

    public static EditProduct = async (product: IEditProductRequestPayload): Promise<any> =>
        await Put<any, IEditProductRequestPayload>(`/products/${product.Uuid}/edit`, product);

    public static DeleteProduct = async (product: IDeleteProductRequestPayload): Promise<any> =>
        await Delete<any>(`/products/${product.Uid}/delete`)

    public static ListProducts = async (): Promise<IProductListItem[]> =>
        await Get<IProductListItem[]>("/products")

    public static GetProductCategories = async (uid: string): Promise<INameUidApiModel[]> =>
        await Get<INameUidApiModel[]>(`/products/${uid}/categories`)

    public static AddProductToCategory = async (request: IAddProductToCategoryRequestPayload): Promise<any> =>
        await Post<any, {}>(`/products/${request.ProductUid}/add-to-category/${request.CategoryUid}`, {});

    public static RemoveProductFromCategory = async (request: IRemoveProductFromCategoryRequestPayload): Promise<any> =>
        await Post<any, {}>(`/products/${request.ProductUid}/remove-from-category/${request.CategoryUid}`, {});

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

    public static UploadImage = async (image: File, productUid: string, index: number) => {
        let imageName = ""

        if (index == 0) {
            imageName = "main"
        }

        else if (index == 1) {
            imageName = "second"
        }

        else {
            imageName = "third"
        }

        await FileService.Upload(image, `Images/${productUid}/${imageName}.png`)
    }
}