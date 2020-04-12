import React from 'react'
import { IProductFormItem } from './Types/IProductFormItem'

export const ProductFormItem: React.FC<IProductFormItem> = (props) =>
    (
        <div className="mb-3 col-md-6">
            <label ><b>{capitalize(props.Name)}:</b></label>
            <input
                name={props.Name}
                type={props.Type}
                placeholder={`Enter ${props.Name}`}
                className="form-control"
                value={props.Value}
                onChange={props.OnChange}>
            </input>
        </div>
    )

const capitalize = (input: string) => input[0].toLocaleUpperCase() + input.slice(1, input.length) 