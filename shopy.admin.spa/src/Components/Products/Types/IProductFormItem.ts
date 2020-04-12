import React from 'react';

export interface IProductFormItem {
    Type: string;
    Name: string;
    Value: any;
    OnChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}