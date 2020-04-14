import { DropDownList } from '../Shared/DropDownList'
import { IProductDropDownProps } from './Types/IProductDropDownProps'
import React from 'react'

export const ProductFormDropDown: React.FC<IProductDropDownProps> = (props) => (
    <div className="mb-3 col-md-3">
        <DropDownList
            Name={props.Name}
            Items={props.Items}
            SelectedItem={props.SelectedItem}
            SelectedItems={props.SelectedItems}
            Multiple={props.Multiple}
            ClassName="custom-select d-block"
            OnChange={props.OnChange}
        />
    </div>
)