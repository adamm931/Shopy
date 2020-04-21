export interface IProductFormImageProps {
    Index: number;
    Url: string;
    File?: File;
    ProductUid: string;
    OnImageChange: (url: string, file: File) => void;
}