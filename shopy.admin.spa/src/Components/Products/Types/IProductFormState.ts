import { IProductFormProps } from './IProductFormProps';

export interface IProductFormState {
    Name: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
}

export const GetStateFromProps = (props: IProductFormProps): IProductFormState => (
    {
        Name: props.Name,
        Description: props.Description,
        Price: props.Price,
        Brand: props.Brand,
        Sizes: props.Sizes,
    })
