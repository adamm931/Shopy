import React from 'react'
import { connect } from 'react-redux'
import { IShopyState } from '../../State/ShopyState'
import { IProductListProps } from './Types/IProductListProps'
import { IProductListDispatch } from './Types/IProductListDispatch'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import ProductItem from './Item'
import { Table } from '../Shared/Table/Table'

class ProductList extends React.Component<IProductListProps & IProductListDispatch> {
    componentDidMount() {
        this.props.List();
    }

    render() {
        return <Table
            Title="Products"
            AddItemUrl="products/add"
            Header={[
                { Name: 'Name' },
                { Name: 'Price ($)' },
            ]}
            ActionsCount={3}
            RenderBody={() => this.props.Products.map((product, index) =>
                <ProductItem
                    key={index}
                    {...product}
                    Index={index}
                />)
            }
        />
    }
}

const mapStateToProps = (state: IShopyState): IProductListProps => ({
    Products: state.ProductList
})

const mapDispatchToProps = (dispatch: any): IProductListDispatch => ({
    List: () => dispatch(RequestFactory.ListProductsRequest())
})

export default connect(mapStateToProps, mapDispatchToProps)(ProductList);