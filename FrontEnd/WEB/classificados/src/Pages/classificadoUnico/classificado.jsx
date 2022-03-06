import React, { useState, useEffect, Component } from "react";

import '../../Assets/css/styles.css';

import axios from 'axios';

export default class Classificado extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idClassificado: 0,
            idUsuario: 0,
            titulo: '',
            descricao: '',
            dataInclusao: Date,
            dataExpiracao: Date,
            situacao: 0,
            ofertas: [],
            descricaoDaOferta: ''
        };
    };

    buscarClassificado = (event) => {
        event.preventDefault();

        axios.get('http://localhost:5000/api/Classificados/ListarMinhas')
            .then(resposta => {
                if (resposta.status === 200) {
                    this.SetState({
                        idClassificado: response.data

                    })
                }
            })
    }

    cancelarClassificado = (event) => {
        event.preventDefault();

        this.setState({ situacao: 2 })

        axios.delete
    }

    cadastrarOferta = (event) => {
        event.preventDefault();

        // Falta colocar o axios post de oferta
    }

    atualizaStateCampo = (campo) => {
        this.SetState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div>
                Classificado Unico
            </div>
        )
    }
}
