import React from 'react'
import { IChangeCategoryItemProps } from './Types/IChangeCategoryItemProps'

export const ChangeCategoryItem: React.FC<IChangeCategoryItemProps> = (props) => (
    <tr>
        <td>{props.Index}</td>
        <td>{props.Name}</td>
        <td>
            <a href="#" onClick={
                () => props.RemoveFrom(props.ProductUid, props.Uid)}
                className="btn btn-danger"
                role="button">Remove
            </a>
        </td>
    </tr>
)