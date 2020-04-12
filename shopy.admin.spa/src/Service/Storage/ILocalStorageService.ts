export interface ILocalStorageService {

    SetItem(key: string, item: any): void;

    GetItem<TItem>(key: string): TItem;

    DeleteItem(key: string): void;

    HasItem(key: string): boolean;
}