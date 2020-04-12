import React from 'react'
import { IDropDownProps } from './Types/IDropDownProps'

export const DropDownList: React.FC<IDropDownProps> = (props) =>
    (
        <select
            name={props.Name}
            className={props.ClassName}
            onChange={props.OnChange}
            multiple={props.Multiple}
        >
            {props.Items.map(item => <option key={item.Key} value={item.Key}>{item.Value}</option>)}
        </select>
    )
