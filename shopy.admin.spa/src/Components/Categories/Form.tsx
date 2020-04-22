import React from "react";
import { CategoryFormState } from "./Types/CategoryFormState";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

class CategoryForm extends React.Component<{}, CategoryFormState> {

    constructor(props: any) {
        super(props)
        this.state = {
            Name: ''
        }
    }

    onSubmit = () => {
        console.log('state', this.state)
    }

    onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault()
        this.setState({
            ...this.state,
            Name: event.target.value
        })
    }

    render() {

        if (this.state == null) {
            return <div></div>
        }

        // TODO: form item shared component

        return <div className="col-md-12 order-md-1">
            <div>
                <h2>Edit category</h2>
                <form onSubmit={this.onSubmit}>
                    <div className="mb-3 col-md-6">
                        <label><b>Name: </b></label>
                        <input name="name" value={this.state.Name} onChange={this.onNameChange} className="form-control" />
                    </div>
                    <div className="col-md-6 row">
                        <div className="col-md-6 mb-3">
                            <button type="submit" className="btn btn-primary btn-lg btn-block">Save</button>
                        </div>
                        <div className="col-md-6 mb-3">
                            <Link to="/categories" className="btn btn-secondary btn-lg btn-block">Cancel</Link>
                        </div>
                    </div>
                </form>
            </div>
        </div >
    }
}


export default connect()(CategoryForm)