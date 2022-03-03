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
            ofertas: []
        };
    };

    buscarClassificado = (event) => {
        event.preventDefault();

        axios.get('http://localhost:5000/api/Classificados')
            .then(resposta => {
                if (resposta.status === 200) {
                    // Precisa colocar o axios get para pegar os dados de um classificado especifico
                }
            })
    }

    cancelarClassificado = (event) => {
        event.preventDefault();

        this.setState({ situacao: 2 })

        // Falta colocar o axios de update para atualizar o banco
    }

    cadastrarClassificado = (event) => {
        event.preventDefault();

        // axios.get('http://localhost:5000/api/Classificado')
        
    }

    return()
}
