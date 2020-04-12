import React from 'react';
import { Switch, Route, Router } from 'react-router'
import Login from '../Login/Login'
import ProductList from '../Products/List';
import CategoriesList from '../Categories/List';
import AuthRoute from '../AuthRoute/AuthRoute';

const Main = () => (
    <main id="content-wrap" role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4 ">
        <Switch>
            <Route exact path="/" component={Login} />
            <AuthRoute path="/products" component={ProductList} />
            <AuthRoute path="/categories" component={CategoriesList} />
        </Switch>
    </main >
)

export default Main