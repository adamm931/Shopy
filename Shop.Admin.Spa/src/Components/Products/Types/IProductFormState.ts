import { IProductFormProps } from './IProductFormProps';
import { IProductFormImageState } from './IProductFormImageState';

export interface IProductFormState {
    Name: string;
    Description: string
    Price: number
    Brand: string
    Sizes: string[]
    Images: IProductFormImageState[]
}

export const GetStateFromProps = (props: IProductFormProps): IProductFormState => (
    {
        Name: props.Name,
        Description: props.Description,
        Price: props.Price,
        Brand: props.Brand,
        Sizes: props.Sizes,
        Images: props.Images.map(image =>
            ({
                Url: image.Url,
                File: image.File
            }))
    })
