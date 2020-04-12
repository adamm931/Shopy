import React from 'react'
import { connect } from 'react-redux'
import { IProductItem } from '../../Models/Products/IProductItem'
import { ProductItem } from '../../Components/Products/Item'

export const products: IProductItem[] = [
    {
        Uuid: "1231241241421412",
        Id: 1,
        Caption: "Product 1",
        Price: "50.24"
    },
    {
        Uuid: "5234125665858543234242",
        Id: 2,
        Caption: "Product 2",
        Price: "150.24"
    },
]

class ProductList extends React.Component {
    render() {
        return <table className="table table-striped table-sm">
            <thead>
                <tr>
                    <th>#ID</th>
                    <th>Caption</th>
                    <th>Price ($)</th>
                    <th colSpan={3}>Actions</th>
                </tr>
            </thead>
            <tbody>
                {products.map(product => <ProductItem key={product.Id} {...product} />)}
            </tbody>
        </table>
    }
}

export default connect()(ProductList);