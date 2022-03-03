import React from 'react';
import ReactDOM from 'react-dom';

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

// import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';

import NotFound from '.pages/notFound/NotFound.js';
import Home from '.pages/home/Home.js';
import Login from '.pages/login/login.jsx';



const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home}/>
        <Route path="/Login" component={Login}/>
        {/* <Route path="/MeusClassificados" component={MeusClassificados}/>
        <Route path="/BuscaClassificados"component={ListagemClassificados}/>
        <Route path="/Classificado" component={Ofertas}/> */}
        <Route path="NotFound" component={NotFound}/>
        <Redirect to="/NotFound"/>
        {/* <Route path="/Destaques" component={Destaques}/> */}
      </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing,
  document.getElementById('root'));
