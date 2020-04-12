import React from 'react'
import { IProductItem } from '../../Models/Products/IProductItem'

export class ProductItem extends React.Component<IProductItem> {

    constructor(props: IProductItem) {
        super(props);
    }

    render() {
        return <tr>
            <td>{this.props.Id}</td>
            <td>{this.props.Caption}</td>
            <td>{this.props.Price}</td>
            <td><a className="btn btn-primary" role="button">Edit</a></td>
            <td><a className="btn btn-secondary" role="button" >Delete</a></td>
            <td><a className="btn btn-secondary" role="button">Change categories</a></td>
        </tr>
    }
}