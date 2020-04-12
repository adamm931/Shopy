import React from 'react'
import { IProductItem } from '../../Models/Products/IProductItem'
import { Link } from 'react-router-dom';

export class ProductItem extends React.Component<IProductItem> {

    constructor(props: IProductItem) {
        super(props);
    }

    render() {
        return <tr>
            <td>{this.props.Id}</td>
            <td>{this.props.Caption}</td>
            <td>{this.props.Price}</td>
            <td><Link to={`products/${this.props.Uuid}/edit`} className="btn btn-primary" role="button">Edit</Link></td>
            <td><Link to={`products/${this.props.Uuid}/delete`} className="btn btn-danger" role="button">Delete</Link></td>
            <td><Link to={`products/${this.props.Uuid}/changeCategories`} className="btn btn-secondary" role="button">Change categories</Link></td>
        </tr>
    }
}