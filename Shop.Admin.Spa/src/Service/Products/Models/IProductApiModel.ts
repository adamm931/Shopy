import { INameIdApiModel } from './../../Api/INameIdApiModel';

export interface IProductApiModel {
    Uid: string;
    Name: string;
    Description: string;
    Price: number;
    Brand: INameIdApiModel;
    Sizes: INameIdApiModel[];
}