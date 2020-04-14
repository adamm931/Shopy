import { IProductFormImageProps } from './IProductFormImageProps';

export interface IProductFormProps {
    Uuid?: string;
    Name: string
    Description: string
    Price: number
    Brand: string
    Sizes: string[]
    Type: ProductFormType
}

export interface IProductFormDispatch {
    Add: (name: string, description: string, price: number, brand: string, sizes: string[]) => void
    Edit: (uuid: string, name: string, description: string, price: number, brand: string, sizes: string[]) => void
}

export type ProductFormType = "Edit" | "Add";