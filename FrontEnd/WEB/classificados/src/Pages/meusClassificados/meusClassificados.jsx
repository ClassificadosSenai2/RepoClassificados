import axios from 'axios';
import { Component } from 'react';

import '../../Assets/css/meusClassificados.css'

export default class MeusClassificados extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaClassificados: [],
            isLoading: false
        }
    };

    listarMeusClassificados = () => {

        axios('http://localhost:5000/api/Classificado/', {
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

    render(){
        return (
            <div className="body">
                <div className="tituloSecao">
                    <h4>MEUS ANÚNCIOS</h4>
                    <button className="btnAnunciar" type="submit">Anunciar</button>
                </div>
                <div className="listaDosClassificados">
                    <div className="classificadoUnico">
                        <div className="imgClassif">
                        </div>
                        <div className="tituloClassif">
                            <h6>Alugue a Lua por sei lá mano, to cansado desse trabalho, só faz ele</h6>
                        </div>
                        <div className="descClassif">
                            <p>abababababababababbaabababababababababbaabababababababababbaabababababababababba</p>
                        </div>
                        <div className="ofertaFavorita">
                            <p></p>
                        </div>
                        <div className="tempoClass">
                        </div>
                    </div>
                </div>
            </div>
        )
    }

}
