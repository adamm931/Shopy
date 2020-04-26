export class StorageUtils {

    public static HasItem(key: string): boolean {
        return localStorage.getItem(key) !== null;
    }

    public static DeleteItem(key: string): void {
        localStorage.removeItem(key);
    }

    public static SetItem(key: string, item: any): void {
        localStorage.setItem(key, JSON.stringify(item))
    }

    public static GetItem<TItem>(key: string): TItem {

        let plainItem = localStorage.getItem(key) || '';
        return JSON.parse(plainItem) as TItem;

    }
}