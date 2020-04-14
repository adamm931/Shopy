import React from 'react'
import ProductForm from './Form'
import { connect } from 'react-redux'

class ProductAdd extends React.Component {

    render() {
        return (
            <ProductForm
                Name=""
                Description=""
                Price={0}
                Brand=""
                Sizes={[]}
                Type="Add" />
        )
    }
}

export default connect()(ProductAdd)