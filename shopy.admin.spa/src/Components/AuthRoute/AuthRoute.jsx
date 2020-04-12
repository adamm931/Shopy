import React from 'react'
import { Redirect, Route } from 'react-router';
import { connect } from 'react-redux'
import { Routes } from '../../Common/Routes';
import { AuthService } from '../../Service/Auth/AuthService';

const AuthRoute = ({ component: Component, isUserLogged, ...rest }) => {
    return (<Route {...rest} render={props => isUserLogged
        ? <Component {...props} />
        : <Redirect to={Routes.Default} />} />)
}


const mapStateToProps = (state) => ({
    isUserLogged: state === undefined ? new AuthService().IsUserLogged() : state.IsUserLogged
})

export default connect(mapStateToProps)(AuthRoute)