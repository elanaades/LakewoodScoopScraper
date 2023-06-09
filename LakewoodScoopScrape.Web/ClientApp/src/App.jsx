import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, Routes } from 'react-router';

import React, { useState } from 'react';
import './App.css';
import Layout from './components/layout'
import Home from './pages/Home';

const App = () => {

    return (
        <Layout>
            <Routes>
                <Route exact path='/' element={<Home />} />
            </Routes>
        </Layout>
    )
}

export default App;