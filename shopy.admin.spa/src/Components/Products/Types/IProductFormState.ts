export interface IProductFormState {
    Caption: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
}

export const EmptyFormState = (): IProductFormState => (
    {
        Caption: '',
        Description: '',
        Price: 0,
        Brand: '',
        Sizes: []
    })
