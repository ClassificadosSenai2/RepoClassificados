import React from 'react';
import ReactDOM from 'react-dom';

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

import { parseJwt, usuarioAutenticado } from './Services/auth.js';

import NotFound from './Pages/notFound/NotFound.js';
import Home from './Pages/home/Home.js';
import Login from './Pages/login/login.jsx';
import Perfil from './Pages/perfil/perfil.jsx';
import Classificado from './Pages/classificadoUnico/classificado.jsx';

const PermissaoComum = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        <Component {...props} />) : (
        <Redirect to="Login"/>
      )
    }
  />
);

const PermissaoAdmin = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />) : (
        <Redirect to="Login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/Login" component={Login} />
        <Route path="/Classificado"component={Classificado}/>
        <Route path="/Perfil" component={Perfil}/>
        <Route path="NotFound" component={NotFound} />
        <Redirect to="/NotFound" />
        {/* <Route path="/Destaques" component={Destaques}/> */}
      </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing,
  document.getElementById('root'));
