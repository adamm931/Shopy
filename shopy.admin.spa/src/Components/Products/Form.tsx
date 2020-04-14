import React from 'react'
import { connect } from 'react-redux'
import { ProductFormItem } from './FormItem'
import { ProductFormButtons } from './FormButtons'
import { IProductFormProps, IProductFormDispatch } from './Types/IProductFormProps'
import { IProductFormState, GetStateFromProps as GetStateFromProps } from './Types/IProductFormState'
import { ProductFormDropDown } from './FormDropDown'
import { ProductUtils } from '../../Utils/ProductUtils'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { } from 'react-router'
import { Routes } from '../../Common/Routes'
import { HistoryUtils } from '../../Utils/HistoryUtils'

type ProductFormPropsType = IProductFormProps & IProductFormDispatch;

class ProductForm extends React.Component<ProductFormPropsType, IProductFormState> {

    constructor(props: ProductFormPropsType) {
        super(props);

        this.state = GetStateFromProps(props);
    }

    onCaptionChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Name: event.target.value
        })
    }

    onDescriptionChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Description: event.target.value
        })
    }

    onPriceChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Price: Number.parseFloat(event.target.value)
        })
    }

    onBrandChanged = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Brand: event.target.value
        })
    }

    onSizesChanged = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();

        var sizes = Array
            .from(event.target.selectedOptions)
            .map(option => option.value);

        this.setState({
            ...this.state,
            Sizes: sizes
        })
    }

    onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        // validate form here

        let data = this.state;

        console.log('state', data);

        if (this.props.Type == "Add") {
            this.props.Add(
                data.Name,
                data.Description,
                data.Price,
                data.Brand,
                data.Sizes)
        }

        else {

            if (this.props.Uuid == undefined) {
                throw 'Product uuid is not present';
            }

            this.props.Edit(
                this.props.Uuid,
                data.Name,
                data.Description,
                data.Price,
                data.Brand,
                data.Sizes)
        }

        HistoryUtils.Redirect(Routes.Products.Root);
    }

    componentWillReceiveProps(newProps: IProductFormProps) {
        this.setState({
            ...this.state,
            Name: newProps.Name,
            Description: newProps.Description,
            Price: newProps.Price,
            Brand: newProps.Brand,
            Sizes: newProps.Sizes
        })
    }

    render() {
        return (
            <div className="col-md-12 order-md-1">
                <div>
                    <h2>{this.props.Type} product</h2>
                </div>
                <form onSubmit={this.onSubmit} encType="multipart/form-data">
                    <ProductFormItem Type="text" Name="caption" Value={this.state.Name} OnChange={this.onCaptionChanged} />
                    <ProductFormItem Type="text" Name="description" Value={this.state.Description} OnChange={this.onDescriptionChanged} />
                    <ProductFormItem Type="number" Name="price" Value={this.state.Price} OnChange={this.onPriceChanged} />

                    <ProductFormDropDown
                        Name="Brand"
                        SelectedItem={this.state.Brand}
                        Items={ProductUtils.GetBrands()}
                        OnChange={this.onBrandChanged}
                    />

                    <ProductFormDropDown
                        Name="Sizes"
                        SelectedItems={this.state.Sizes}
                        Items={ProductUtils.GetSizes()}
                        Multiple
                        OnChange={this.onSizesChanged}
                    />

                    {/* <ProductFormImage
                        Index={0} {...this.props.Images[0]}
                        OnChange={(event) => this.onImageChanged(event, 0)}
                    />

                    <ProductFormImage
                        Index={1} {...this.props.Images[1]}
                        OnChange={(event) => this.onImageChanged(event, 1)}
                    />

                    <ProductFormImage
                        Index={2} {...this.props.Images[2]}
                        OnChange={(event) => this.onImageChanged(event, 2)}
                    /> */}

                    <ProductFormButtons />
                </form >
            </div>
        )
    }
}

const mapDispatchToProps = (dispatch: any): IProductFormDispatch => ({
    Add: (caption: string, description: string, price: number, brand: string, sizes: string[]) =>
        dispatch(RequestFactory.AddProductRequest(caption, description, price, brand, sizes)),
    Edit: (uuid: string, caption: string, description: string, price: number, brand: string, sizes: string[]) =>
        dispatch(RequestFactory.EditProductRequest(uuid, caption, description, price, brand, sizes))
})

export default connect(null, mapDispatchToProps)(ProductForm)