import '../../Assets/css/styles.css'
import '../../Assets/css/perfil.css'
import Header from "../../Components/header.jsx"

import { Component } from "react";
import axios from 'axios';

export default class Perfil extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idUsuario: 0,
            nome: '',
            sobrenome: '',
            email: '',
            ddd: 0,
            telefone: 0
        }
    };

    buscarInformacoes = () => {
        axios('http://localhost:5000/api/Usuarios/', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
    }

    render() {
        return (
            <div>
                <Header />
                <section>
                    <h1>Perfil - Informações Pessoaiss</h1>
                    <div>
                        <img />
                        <div>
                            
                        </div>
                    </div>
                </section>
            </div>

        )
    }
}