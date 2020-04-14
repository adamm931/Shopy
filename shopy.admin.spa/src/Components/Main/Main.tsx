import React from 'react'
import { Switch, Route, withRouter } from 'react-router-dom'
import Login from '../Login/Login'
import ProductList from '../Products/List'
import CategoriesList from '../Categories/List'
import AuthRoute from '../AuthRoute/AuthRoute'
import ProductEdit from '../Products/Edit'
import ProductAdd from '../Products/Add'

const Main = () => (
    <main id="content-wrap" role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4 ">
        <Switch>
            <Route exact path="/" component={Login} />
            <AuthRoute exact path="/products" component={ProductList} />
            <AuthRoute exact path="/products/add" component={ProductAdd} />
            <AuthRoute exact path="/products/:id/edit" component={ProductEdit} />
            <AuthRoute exact path="/categories" component={CategoriesList} />
        </Switch>
    </main>
)

export default Main