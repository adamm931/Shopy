export interface IProductFormImageProps {
    Index: number;
    Url: string;
    File?: File;
    OnImageChange: (url: string, file: File) => void;
}