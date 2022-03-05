import '../../Assets/css/styles.css'
import '../../Assets/css/perfil.css'
import Header from "../../Components/header.jsx"
import PerfilGenerico from "../../Assets/img/Perfil_Generico.png"

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
            <main>
                <Header />
                <section>
                    <h1>Perfil - Informações Pessoais</h1>
                    <div className='apoioPerfil'>
                        <div className='apoioImagemPerfil'>
                            <img src={PerfilGenerico} />
                        </div>
                        <div className='apoioForm'>
                            <form>

                                <div className='linhasInputs'>
                                    <input name='nome' placeholder='Nome' type="text"></input>
                                    <input name='sobrenome' placeholder='Sobrenome' type="text"></input>
                                </div>

                                <div className='linhasInputs'>
                                    <input name='email' placeholder='Email' type='email' id='emailInput' ></input>
                                </div>

                                <div className='linhasInputs'>
                                    <input name='ddd' placeholder='DDD' type="number"></input>
                                    <input name='telefone' placeholder='Telefone' type="number"></input>
                                </div>

                                <button type='submit'>Atualizar</button>
                            </form>
                        </div>
                    </div>
                </section>
            </main>

        )
    }
}