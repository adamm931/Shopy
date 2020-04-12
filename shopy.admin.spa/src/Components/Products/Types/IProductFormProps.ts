export interface IProductFormProps {
    Caption: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
    Type: ProductFormType;
}

export type ProductFormType = "Edit" | "Add";