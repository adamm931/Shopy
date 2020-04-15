import React from 'react'
import ProductForm from './Form'
import { connect } from 'react-redux'
import { IShopyState, EmptyEditingProduct } from '../../State/ShopyState';
import { IProductEditProps } from './Types/IProductEditProps'
import { IProductEditDispatch } from './Types/IProductEditDisptach'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { RouteComponentProps } from 'react-router-dom';
import { RouteUtils } from '../../Utils/RouterUtils'

type Props = IProductEditDispatch & IProductEditProps & RouteComponentProps

class ProductEdit extends React.Component<Props, IProductEditProps> {

    constructor(props: Props) {
        super(props)

        this.setState(EmptyEditingProduct())
    }

    componentDidMount() {
        this.props.RequestGetProduct(RouteUtils.GetIdParam(this.props));
    }

    componentWillReceiveProps(nextProps: IProductEditProps) {
        this.setState(nextProps)
    }

    render() {
        return this.state == null
            ? <React.Fragment />
            : (
                <ProductForm
                    Uuid={RouteUtils.GetIdParam(this.props)}
                    Name={this.state.Name}
                    Description={this.state.Description}
                    Price={this.state.Price}
                    Brand={this.state.Brand}
                    Sizes={this.state.Sizes}
                    Type="Edit"
                />
            )
    }
}

const mapStateToProps = (state: IShopyState): IProductEditProps => {
    return state !== undefined ?
        {
            Name: state.EditingProduct.Name,
            Description: state.EditingProduct.Description,
            Price: state.EditingProduct.Price,
            Brand: state.EditingProduct.Brand,
            Sizes: state.EditingProduct.Sizes,
        } : EmptyEditingProduct()
}

const mapDisptachToProps = (dispatch: any): IProductEditDispatch => ({
    RequestGetProduct: (uid: string) => dispatch(RequestFactory.GetProductRequest(uid))
})

export default connect(mapStateToProps, mapDisptachToProps)(ProductEdit)