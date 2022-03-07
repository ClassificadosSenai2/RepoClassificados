import React, { Component } from "react";

import '../../Assets/css/styles.css';
import '../../Assets/css/classificado.css';

import imagemClassificado from '../../Assets/img/ImagemPadraoClassificado.jpg'

import Header from "../../Components/header.jsx"

import axios from 'axios';

export default class Classificado extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idClassificado: 1,
            idUsuario: 0,
            titulo: '',
            descricao: '',
            dataInclusao: Date,
            dataExpiracao: Date,
            situacao: 0,
            ofertas: [],
            idOferta: 0,
            descricaoDaOferta: ''
        };
    };

    buscarClassificado = () => {

        axios.get('https://localhost:5000/Classificados/' + this.state.idClassificado + '/Ofertas/')
            .then(resposta => {
                if (resposta.status === 200) {

                }
            })
    }


    atualizaStateCampo = (campo) => {
        this.SetState({ [campo.target.name]: campo.target.value })
    }

    componentDidMount() {
        this.buscarClassificado()
    }

    render() {
        return (
            <div>
                <Header />
                <section className="apoioClassificado">
                    <div className="blocoEsquerdo">
                        <div className="apoioInfos">
                            <h1>Titulo Classificado</h1>
                            <span>300 Centavos</span>
                            <p>DescricaoClassificado</p>
                        </div>
                        <form>
                            <textarea wrap="hard" onChange={this.atualizaStateCampo} value={this.state.descricaoDaOferta} name='descricaoDaOferta' type="text" placeholder="Escreva um pouco sobre a sua oferta"></textarea>
                            <button>Ofertar</button>
                        </form>
                    </div>


                    <div className="blocoDireito">
                        <img src={imagemClassificado} />
                        <div>Relógio</div>
                    </div>
                </section>

                <section className="apoioClassificado1">
                    <div className="apoioOfertas">
                        <div className="tituloOfertas">
                            <h1>Ofertas feitas pelos usuarios</h1>
                        </div>
                        <div>
                            <div className="avisoOferta">
                                <h2>Oferta favorita</h2>
                            </div>
                            <div className="blocoOferta">
                                <div className="nomeUsuario">
                                    <h3>NomeUsuario</h3>
                                </div>
                                <div className="ofertaUsuario">
                                    <span>300 Centavos</span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className="divTodasOfertas">
                        <div className="todasOfertas">
                            <h2>Todas as Ofertas</h2>
                        </div>
                        <div className="blocoOferta">
                            <div className="nomeUsuario">
                                <h3>Nome Ofertante</h3>
                            </div>
                            <div className="ofertaUsuario">
                                <span>DescricaoDaOferta</span>
                            </div>
                        </div>

                    </div>
                </section >
            </div>

        )
    }
}
