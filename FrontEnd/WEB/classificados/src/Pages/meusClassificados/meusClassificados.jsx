import axios from 'axios';
import { Component } from 'react';

export default class MeusClassificados extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaClassificados: [],
            isLoading: false
        }
    };

    listarMeusClassificados = () => {

        axios('http://localhost:5000/api/Classificado/meus', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(response => {
                if (response.status === 200) {
                    this.setState({ listaClassificados: response.data })
                }
            })
            .catch( erro => console.log(erro));
    }

    // anunciarClassificado = () => {
    //     this.setState({ erro: '', isLoading: true });

    //     axios.post('http://localhost:5000/api/Classificado')
    // }

    // Precisa saber onde os campos de cadastroClassificados ficará

}
