import React from 'react'
import { connect } from 'react-redux'
import { ILoginFormState } from './Types/ILoginFormState'
import { ILoginFormDispatch } from './Types/ILoginFormDispatch'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'

const initialState: ILoginFormState = {
    Username: "",
    Password: ""
}

class Login extends React.Component<ILoginFormDispatch, ILoginFormState> {

    constructor(props: any) {
        super(props);

        this.state = initialState;
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
            Password: event.target.value
        });
    }

    onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        this.props.LoginUser(this.state);
        this.setState(initialState);
    }

    render() {
        return (<div>
            <form className="form-signin" onSubmit={this.onSubmit}>
                <h1 className="h3 mb-3 font-weight-normal">Please sign in: </h1>
                <input
                    className="form-control mb-2"
                    id="username"
                    type="text"
                    name="username"
                    onChange={this.onChangeUsername}
                    placeholder="Enter username" />
                <input
                    className="form-control mb-2"
                    id="password"
                    type="password"
                    name="password"
                    onChange={this.onChangePassword}
                    placeholder="Enter password" />
                <span className="float-left mr-2 w-100">
                    Remember me: <input type="checkbox"></input>
                </span>
                <button className="btn btn-primary form-control w-75" type="submit">
                    Login:
                    </button>
            </form>
        </div >)
    }
}

const mapDispatchToProps = (dispatch: any): ILoginFormDispatch => ({
    LoginUser: (state: ILoginFormState) => dispatch(RequestFactory.LoginUserRequest(state.Username, state.Password))
})

export default connect(null, mapDispatchToProps)(Login)