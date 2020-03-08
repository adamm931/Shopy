import React from 'react';
import { Switch, Route } from 'react-router'
import Login from '../Login/Login'

const Main: React.FC = () => (
    <main id="content-wrap" role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4 ">
        <Switch>
            <Route exact path="/">
                <Login />
            </Route>
            <Route path="/products">
                <div>
                    Products...
            </div>
            </Route>
            <Route path="/categories">
                <div>
                    Categories...
            </div>
            </Route>
        </Switch>
    </main>
)

export default Main