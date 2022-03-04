import React from "react";
import logo from "../Assets/img/Logomarca_aakshn_todo_resto.png";
import "../Assets/css/header.css";
import "../Assets/css/styles.css";

import { Link, useHistory }from "react-router-dom"

export default function Header() {
    return (
        <header>
            <div className="apoioHeader">
                <img src={logo} id="logoHeader" />

                <div className="blocoPesquisaLinks">

                    <div className="blocoPesquisa">
                        <input></input>
                        <button>Pesquisar</button>
                    </div>

                    <nav className="linksHeader">
                        <Link to="" className="linkHeader">Categorias</Link>
                        <Link to="" className="linkHeader">Em alta</Link>
                        <Link to="" className="linkHeader">Perfil</Link>
                        <Link to="" className="linkHeader">Meus Anúncios</Link>
                    </nav>

                </div>

            </div>

        </header>
    )
}