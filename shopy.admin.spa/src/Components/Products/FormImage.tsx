import React from 'react'
import { IProductFormImageProps } from './Types/IProductFormImageProps'
import { ProductFormItem } from './FormItem'

export const ProductFormImage: React.FC<IProductFormImageProps> = (props) => (
    <div className="ml-3 row">
        <ProductFormItem
            Type="file"
            Name={`image_${props.Index}`}
            Value={props.File}
            OnChange={props.OnChange}
        />
        <img className="ml-3 mt-2 mb-2" width="100" height="100" src={props.Url} alt="" />
    </div>
)