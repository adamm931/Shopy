import React from 'react'
import { connect } from 'react-redux'
import { ILoginFormState } from './Types/ILoginFormState'
import { ILoginFormDispatch } from './Types/ILoginFormDispatch'
import { ILoginFormProps } from './Types/ILoginFormProps'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { IShopyState } from '../../State/ShopyState'
import { Routes } from '../../Enums/Routes'
import { HistoryUtils } from '../../Utils/HistoryUtils'

class Login extends React.Component<ILoginFormDispatch & ILoginFormProps, ILoginFormState> {

    constructor(props: any) {
        super(props);

        this.state = {
            Username: "",
            Password: "",
            IsUserLogged: false
        };
    }

    onChangeUsername = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Username: event.target.value
        });
    }

    onChangePassword = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Password: event.target.value
        });
    }

    onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (!this.isValidForm()) {
            throw 'Form is invalid'
        }

        this.props.LoginUser(this.state);
        this.setState({
            ...this.state,
            Username: '',
            Password: ''
        });

        HistoryUtils.Redirect(Routes.Products.Root);
    }

    isValidForm = () => {
        return this.state.Password !== '' && this.state.Username !== '';
    }

    render() {

        // if (this.props.IsUserLogged) {
        //     return <Redirect to={Routes.Products.Root} />
        // }

        return (<div>
            <form className="form-signin" onSubmit={this.onSubmit} autoComplete="off" >
                <h1 className="h3 mb-3 font-weight-normal">Please sign in</h1>
                <input
                    className="form-control mb-2"
                    id="username"
                    type="text"
                    name="username"
                    onChange={this.onChangeUsername}
                    placeholder="Enter username" />
                <input
                    className="form-control mb-2"
                    id="current-password"
                    type="password"
                    name="current-password"
                    onChange={this.onChangePassword}
                    placeholder="Enter password" />
                <span className="float-left mr-2 w-100">
                    Remember me: <input type="checkbox"></input>
                </span>
                <button className="btn btn-primary form-control w-75" type="submit">
                    Login
                </button>
            </form>
        </div >)
    }
}

const mapDispatchToProps = (dispatch: any): ILoginFormDispatch => ({
    LoginUser: (state: ILoginFormState) => dispatch(RequestFactory.LoginUserRequest(state.Username, state.Password))
})

const mapStateToProps = (state: IShopyState): ILoginFormProps => ({
    IsUserLogged: state !== undefined ? state.IsUserLogged : false
})

export default connect(mapStateToProps, mapDispatchToProps)(Login)