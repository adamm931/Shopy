import React from 'react'
import { IDropDownProps } from './Types/IDropDownProps'
import { IKeyValue } from './Types/IKeyValue'

export const DropDownList: React.FC<IDropDownProps> = (props) =>
    (
        <select
            name={props.Name}
            className={props.ClassName}
            onChange={props.OnChange}
            multiple={props.Multiple}
        >
            {props.Items.map(item => <option
                key={item.Key}
                value={item.Key}
                selected={isSelected(item, props)}>{item.Value}
            </option>)}
        </select>
    )


const isSelected = (item: IKeyValue, props: IDropDownProps) => props.Multiple
    ? props.SelectedItems?.some(selectedItem => selectedItem == item.Key)
    : item.Key == props.SelectedItem;