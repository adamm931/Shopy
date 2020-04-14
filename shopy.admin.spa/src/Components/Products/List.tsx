import React from 'react'
import { connect } from 'react-redux'
import { ProductItem } from '../../Components/Products/Item'
import { IShopyState } from '../../State/ShopyState'
import { IProductListProps } from './Types/IProductListProps'
import { IProductListDispatch } from './Types/IProductListDispatch'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { Link, withRouter } from 'react-router-dom'

class ProductList extends React.Component<IProductListProps & IProductListDispatch> {
    componentDidMount() {
        this.props.List();
    }

    render() {
        return (
            <React.Fragment>
                <h2>Products <Link to="products/add" className="btn btn-success">Add</Link></h2>
                <div className="table-responsive">
                    <table className="table table-striped table-sm">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Caption</th>
                                <th>Price ($)</th>
                                <th colSpan={3}>Actions</th>
                            </tr>
                        </thead >
                        <tbody>
                            {this.props.Products.map((product, index) => <ProductItem key={index} {...product} Index={index} />)}
                        </tbody>
                    </table>
                </div>
            </React.Fragment>
        )
    }
}

const mapStateToProps = (state: IShopyState): IProductListProps => ({
    Products: state == undefined ? [] : state.ProductList
})

const mapDispatchToProps = (dispatch: any): IProductListDispatch => ({
    List: () => dispatch(RequestFactory.ListProductsRequest())
})

export default connect(mapStateToProps, mapDispatchToProps)(ProductList);