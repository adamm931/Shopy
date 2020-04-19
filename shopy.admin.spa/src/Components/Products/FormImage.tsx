import React from 'react'
import { IProductFormImageProps } from './Types/IProductFormImageProps'
import { ProductUtils } from '../../Utils/ProductUtils'
import { IProductFormImageState } from './Types/IProductFormImageState'

export class ProductFormImage extends React.Component<IProductFormImageProps, IProductFormImageState> {

    constructor(props: IProductFormImageProps) {
        super(props)

        this.state = {
            Url: ProductUtils.DefaultImageUrl,
        }
    }

    onImageChanged = (event: React.ChangeEvent<HTMLInputElement>) => {

        if (event.target.files === null) {
            return;
        }

        let imageFile = event.target.files[0]
        let imageUrl = URL.createObjectURL(imageFile)

        this.setState({
            ...this.state,
            Url: imageUrl
        })

        if (this.props.OnImageChange === null) {
            return
        }

        this.props.OnImageChange(imageUrl, imageFile)
    }

    render() {
        return (<div className="col-md-2 mr-2 border">
            <label className="custom-file-label">
                <b>{`Image ${this.props.Index}`}:</b>
            </label>
            <input
                name={`image_${this.props.Index}`}
                type="file"
                className="custom-file-input"
                onChange={this.onImageChanged}>
            </input>
            <img className="ml-3 mt-2 mb-2" width="100" height="100" src={this.state.Url} alt="" />
        </div>)
    }
}