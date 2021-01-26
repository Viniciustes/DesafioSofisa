import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { GitHub } from './components/GitHub';
import { GitHubDetalhe } from './components/GitHubDetalhe';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={GitHub} />
                <Route path='/git-hub' component={GitHub} />
                <Route path='/git-hub-detalhe' component={GitHubDetalhe} />
            </Layout>
        );
    }
}