import React from 'react'
import { CategoryListItemProps } from './Types/CategoryListItemProps'
import { Link } from 'react-router-dom'

export const CategoryListItem: React.FC<CategoryListItemProps> = (props) => (
    <tr>
        <td>{props.Index}</td>
        <td>{props.Name}</td>
        <td><Link to={`categories/${props.Uid}/edit`} className="btn btn-primary" onClick={onEdit}>Edit</Link></td>
        <td><button className="btn btn-danger" onClick={onDelete}>Delete</button></td>
    </tr>
)

const onEdit = () => console.log("on edit")

const onDelete = () => console.log("on delete")
