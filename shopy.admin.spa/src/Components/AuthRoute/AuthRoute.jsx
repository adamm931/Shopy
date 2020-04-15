import React from 'react'
import { Redirect, Route } from 'react-router';
import { connect } from 'react-redux'
import { Routes } from '../../Common/Routes';
import { AuthService } from '../../Service/Auth/AuthService';
import { HistoryUtils } from '../../Utils/HistoryUtils';
import * as ActionFactory from '../../State/Actions/Factory/ActionFactory'

const AuthRoute = ({ component: Component, isUserLogged, redirectTo, dispatch, ...rest }) => {

    if (redirectTo != undefined) {
        HistoryUtils.Redirect(redirectTo)
        dispatch(ActionFactory.ClearRedirect())
    }

    return <Route {...rest} render={props => {

        if (isUserLogged) {
            return <Component {...props} />
        }

        return <Redirect to={Routes.Root} />
    }} />
}

const mapStateToProps = (state) => {

    let props = {
        isUserLogged: new AuthService().IsUserLogged()
    };

    if (state !== undefined) {
        props.redirectTo = state.RedirectTo
    }

    return props
}

export default connect(mapStateToProps)(AuthRoute)