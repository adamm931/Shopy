import React from "react";
import { CategoryFormState } from "./Types/CategoryFormState";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import { CategoryFormProps } from "./Types/CategoryFormProps";
import { CategoryFormDispatch } from "./Types/CategoryFormDispatch";
import { FormType } from "../../Enums/FormType";
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'

type Props = CategoryFormProps & CategoryFormDispatch

class CategoryForm extends React.Component<Props, CategoryFormState> {

    constructor(props: Props) {
        super(props)
        this.state = {
            Name: ''
        }
    }

    componentWillReceiveProps(props: CategoryFormProps) {
        this.setState({
            ...this.state,
            ...props
        })
    }

    onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (this.props.Type == FormType.ADD) {
            this.props.Add(this.state.Name)
        }

        else if (this.props.Type == FormType.EDIT) {

            if (this.props.Uid == undefined) {
                throw 'Category uid is not passed'
            }

            this.props.Edit(this.props.Uid, this.state.Name)
        }

        else {
            console.warn("Unknow form type:", this.props.Type)
        }

        this.setState({})
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
            return null
        }

        return <div className="col-md-12 order-md-1">
            <div>
                <h2>{this.props.Type} category</h2>
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

const mapDispatchToProps = (dispatch: any): CategoryFormDispatch => ({
    Add: (name: string) => dispatch(RequestFactory.AddCategory(name)),
    Edit: (uid: string, name: string) => dispatch(RequestFactory.EditCategory(uid, name))
})


export default connect(null, mapDispatchToProps)(CategoryForm)