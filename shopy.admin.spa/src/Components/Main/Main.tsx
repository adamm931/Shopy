import React from 'react';
import { Switch, Route, Router } from 'react-router'
import Login from '../Login/Login'
import ProductList from '../Products/List'
import CategoriesList from '../Categories/List'
import AuthRoute from '../AuthRoute/AuthRoute'
import ProductForm from '../Products/Form'

const Main = () => (
    <main id="content-wrap" role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4 ">
        <Switch>
            <Route exact path="/" component={Login} />
            <AuthRoute exact path="/products" component={ProductList} />
            <AuthRoute exact path="/products/:id/edit" component={ProductForm} />
            <AuthRoute exact path="/categories" component={CategoriesList} />
        </Switch>
    </main >
)

export default Main