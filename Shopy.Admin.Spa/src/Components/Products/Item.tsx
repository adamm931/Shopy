import React from 'react'
import { Link } from 'react-router-dom';
import { IProductListItemDispatch } from './Types/IProductListItemDispatch'
import { IProductListItemProps } from './Types/IProductListItemProps'
import { connect } from 'react-redux';
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'

type Props = IProductListItemProps & IProductListItemDispatch

const ProductItem: React.FC<Props> = (props) => <tr>
    <td>{props.Index}</td>
    <td>{props.Name}</td>
    <td>{props.Price}</td>
    <td><Link to={`products/${props.Uid}/edit`} className="btn btn-primary" role="button">Edit</Link></td>
    <td><Link to="#" onClick={() => onDeleteClicked(props)} className="btn btn-danger">Delete</Link></td>
    <td><Link to={`products/${props.Uid}/changeCategories`} className="btn btn-secondary" role="button">Change categories</Link></td>
</tr>

const onDeleteClicked = (props: Props) => {
    props.Delete(props.Uid)
}

const mapDispatchToProps = (dispatch: any): IProductListItemDispatch => ({
    Delete: (uid: string) => (dispatch(RequestFactory.DeleteProductRequest(uid)))
})

export default connect(null, mapDispatchToProps)(ProductItem)