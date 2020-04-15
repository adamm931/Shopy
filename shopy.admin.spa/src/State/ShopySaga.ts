import { CategoryService } from './../Service/Categories/CategoryService';
import { INameUidApiModel } from './../Service/Api/INameUidApiModel';
import { IDeleteProductRequest } from './Requests/Products/IDeleteProductRequest';
import { IProduct } from '../Service/Products/IProduct'
import { IGetProductRequest } from './Requests/Products/IGetPropductRequest';
import { IEditProductRequest } from './Requests/Products/IEditProductRequest';
import { IProductListItem } from '../Service/Products/IProductListItem';
import { ProductsService } from '../Service/Products/ProductsService';
import { IAddProductRequest } from './Requests/Products/IAddProductRequest';
import { AuthenticateRequest } from '../Service/Auth/LoginRequest';
import { RequestTypes } from './Requests/Base/RequestTypes';
import { ILoginUserRequest } from './Requests/Login/ILoginUserRequest';
import { all, put, takeLatest, call } from 'redux-saga/effects'
import { AuthService } from '../Service/Auth/AuthService';
import * as ActionFactory from './Actions/Factory/ActionFactory';
import { IAuthenticateResponse } from '../Service/Auth/ILoginResponse';
import { IProductsListRequest } from './Requests/Products/IProductsListRequest';
import { Routes } from '../Common/Routes';
import { IAddProductToCategoryRequest } from './Requests/Products/IAddProductToCategoryRequest';
import { IRemoveProductFromCategoryRequest } from './Requests/Products/IRemoveProductFromCategoryRequest';

function* WatchLoginUser() {
    yield takeLatest(RequestTypes.LOGIN_USER, LoginUser)
}

function* WatchLogoutUser() {
    yield takeLatest(RequestTypes.LOGOUT_USER, LogoutUser)
}

function* WatchProductAdd() {
    yield takeLatest(RequestTypes.ADD_PRODUCT, AddProduct)
}

function* WatchProductEdit() {
    yield takeLatest(RequestTypes.EDIT_PRODUCT, EditProduct)
}

function* WatchProductDelete() {
    yield takeLatest(RequestTypes.DELETE_PRODUCT, DeleteProduct)
}

function* WatchProductGet() {
    yield takeLatest(RequestTypes.GET_PRODUCT, GetProduct)
}

function* WatchProductList() {
    yield takeLatest(RequestTypes.LIST_PRODUCTS, ListProducts)
}

function* WatchProductGetCategories() {
    yield takeLatest(RequestTypes.GET_PRODUCT_CATEGORIES, GetProductCategories)
}

function* WatchProductAddToCategory() {
    yield takeLatest(RequestTypes.ADD_PRODUCT_TO_CATEGORY, AddProductToCategory)
}

function* WatchProductRemoveFromCategory() {
    yield takeLatest(RequestTypes.REMOVE_PRODUCT_FROM_CATEGORY, RemoveProductFromCategory)
}

function* WatchCategoriesLookup() {
    yield takeLatest(RequestTypes.LOOKUP_CATEGORIES, LookupCategories)
}

function* LoginUser(request: ILoginUserRequest) {

    var authService = new AuthService();
    var payload = request.Payload;
    var loginRequest = new AuthenticateRequest(payload.Username, payload.Password);

    var authenticateResponse: IAuthenticateResponse = yield call(() => authService.AuthenticateAsync(loginRequest));

    if (authenticateResponse.IsAuthenticated) {
        yield put(ActionFactory.UserLogedIn());
        yield put(ActionFactory.Redirect(Routes.Products.Root))
    }
}

function* LogoutUser() {
    var authService = new AuthService();
    authService.LogoutUser();
    yield put(ActionFactory.Redirect(Routes.Root))
}

function* AddProduct(request: IAddProductRequest) {
    yield call(() => ProductsService.AddProduct(request.Payload));
    yield put(ActionFactory.Redirect(Routes.Products.Root))
}

function* EditProduct(request: IEditProductRequest) {
    yield call(() => ProductsService.EditProduct(request.Payload));
    yield put(ActionFactory.Redirect(Routes.Products.Root))
}

function* GetProduct(request: IGetProductRequest) {
    var product: IProduct = yield call(() => ProductsService.GetProduct(request.Payload));
    yield put(ActionFactory.ProductEdit(product))
}

function* DeleteProduct(request: IDeleteProductRequest) {
    yield call(() => ProductsService.DeleteProduct(request.Payload));
    yield put(ActionFactory.ProductDeleted(request.Payload.Uid))
}

function* ListProducts(request: IProductsListRequest) {
    var products: IProductListItem[] = yield call(() => ProductsService.ListProducts());
    yield put(ActionFactory.ProductList(products));
}

function* GetProductCategories(request: IGetProductRequest) {
    var productCategories: INameUidApiModel[] = yield call(() => ProductsService.GetProductCategories(request.Payload.Uid));
    yield put(ActionFactory.ProductCategories(productCategories));
}

function* AddProductToCategory(request: IAddProductToCategoryRequest) {
    let payload = request.Payload
    yield call(() => ProductsService.AddProductToCategory(request.Payload));
    yield put(ActionFactory.ProductAddedToCategory(payload.ProductUid, payload.CategoryUid));
}

function* RemoveProductFromCategory(request: IRemoveProductFromCategoryRequest) {
    let payload = request.Payload
    yield call(() => ProductsService.RemoveProductFromCategory(payload));
    yield put(ActionFactory.ProductRemovedFromCategory(payload.ProductUid, payload.CategoryUid));
}

function* LookupCategories(request: IProductsListRequest) {
    var lookup: INameUidApiModel[] = yield call(() => CategoryService.Lookup())
    yield put(ActionFactory.LookupCategories(lookup));
}

export function* Watch() {
    yield all([
        WatchLoginUser(),
        WatchLogoutUser(),
        WatchProductAdd(),
        WatchProductList(),
        WatchProductEdit(),
        WatchProductDelete(),
        WatchProductGet(),
        WatchProductGetCategories(),
        WatchProductAddToCategory(),
        WatchProductRemoveFromCategory(),
        WatchCategoriesLookup()
    ])
}