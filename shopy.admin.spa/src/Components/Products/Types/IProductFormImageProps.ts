export interface IProductFormImageProps {
    Index: number;
    Url: string;
    File?: File;
    OnChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
}