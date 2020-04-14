import React from 'react'
import { IProductListItem } from '../../Service/Products/IProductListItem'
import { Link } from 'react-router-dom';

export class ProductItem extends React.Component<IProductListItem> {

    constructor(props: IProductListItem) {
        super(props);
    }

    render() {
        return <tr>
            <td>{this.props.Index}</td>
            <td>{this.props.Name}</td>
            <td>{this.props.Price}</td>
            <td><Link to={`products/${this.props.Uid}/edit`} className="btn btn-primary" role="button">Edit</Link></td>
            <td><Link to={`products/${this.props.Uid}/delete`} className="btn btn-danger" role="button">Delete</Link></td>
            <td><Link to={`products/${this.props.Uid}/changeCategories`} className="btn btn-secondary" role="button">Change categories</Link></td>
        </tr>
    }
}