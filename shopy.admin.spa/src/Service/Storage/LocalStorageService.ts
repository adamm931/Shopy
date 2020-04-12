import { ILocalStorageService } from './ILocalStorageService';

export class LocalStorageService implements ILocalStorageService {

    private constructor() {
    }

    HasItem(key: string): boolean {
        return localStorage.getItem(key) !== null;
    }

    DeleteItem(key: string): void {
        localStorage.removeItem(key);
    }

    SetItem(key: string, item: any): void {
        localStorage.setItem(key, JSON.stringify(item))
    }

    GetItem<TItem>(key: string): TItem {

        let plainItem = localStorage.getItem(key) || '';
        return JSON.parse(plainItem) as TItem;

    }

    public static Create = (): ILocalStorageService => new LocalStorageService();
}