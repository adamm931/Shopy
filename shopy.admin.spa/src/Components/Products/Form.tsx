import React from 'react'
import { connect } from 'react-redux'
import { ProductFormItem } from './FormItem'
import { ProductFormButtons } from './FormButtons'
import { IProductFormProps } from './Types/IProductFormProps'
import { IProductFormState, EmptyFormState as EmptyFormState } from './Types/IProductFormState'
import { ProductFormDropDown } from './FormDropDown'
import { ProductUtils } from '../../Utils/ProductUtils'

class ProductForm extends React.Component<IProductFormProps, IProductFormState> {

    constructor(props: IProductFormProps) {
        super(props);

        this.state = EmptyFormState();
    }

    onCaptionChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Caption: event.target.value
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

        console.log('state', this.state);

        // request submit with saga
    }

    render() {

        return (
            <div className="col-md-12 order-md-1">
                <div>
                    <h2>{this.props.Type} product</h2>
                </div>
                <form onSubmit={this.onSubmit} >
                    <ProductFormItem Type="text" Name="caption" Value={this.props.Caption} OnChange={this.onCaptionChanged} />
                    <ProductFormItem Type="text" Name="description" Value={this.props.Description} OnChange={this.onDescriptionChanged} />
                    <ProductFormItem Type="number" Name="price" Value={this.props.Price} OnChange={this.onPriceChanged} />

                    <ProductFormDropDown
                        Name="Brand"
                        Items={ProductUtils.GetBrands()}
                        OnChange={this.onBrandChanged}
                    />

                    <ProductFormDropDown
                        Name="Sizes"
                        Items={ProductUtils.GetSizes()}
                        Multiple
                        OnChange={this.onSizesChanged}
                    />

                    <ProductFormButtons />
                </form >
            </div>
        )
    }
}

export default connect()(ProductForm)