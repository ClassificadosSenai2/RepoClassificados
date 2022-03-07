import axios from 'axios';
import { Component } from 'react';

import '../../Assets/css/meusClassificados.css'

import Header from "../../Components/header.jsx"

export default class MeusClassificados extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaClassificados: [],
            isLoading: false
        }
    };

    listarMeusClassificados = () => {

        axios('http://localhost:5000/api/Classificado/ListarMinhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(response => {
                if (response.status === 200) {
                    this.setState({ listaClassificados: response.data })
                }
            })
            .catch(erro => console.log(erro));
    }

    // anunciarClassificado = () => {
    //     this.setState({ erro: '', isLoading: true });

    //     axios.post('http://localhost:5000/api/Classificado')
    // }

    render() {
        return (
            <div>
                <Header />
                <div className="body">
                    <div className="tituloSecao">
                        <h4>MEUS ANÚNCIOS</h4>
                        <button className="btnAnunciar" type="submit"><h5>Anunciar</h5></button>
                    </div>
                    <div className="listaDosClassificados">
                        {/* {this.listarMeusClassificados.map((meusClassificados) => {
                            return ( */}
                                <div className="classificadoUnico">
                                    <div className="imgClassif">
                                        {/* {meusClassificados.Imagem} */}
                                    </div>
                                    <div className='infoClassif'>
                                        <div className='infoClassifTeD'>
                                            <div className="tituloClassif">
                                                <h6>Alugue a Lua por sei lá mano, to cansado desse trabalho, só faz ele</h6>
                                                <h6>
                                                    {/* {meusClassificados.Titulo} */}
                                                    </h6>
                                            </div>
                                            <div className='linhaClassif' />
                                            <div className="descClassif">
                                                <p>Já imaginou ter um cruzeiro de ida lunar? Não? Pois bem, te alugo um pedaço da Lua para você ter essa experiência!</p>
                                                {/* <p>{meusClassificados.Descricao}</p> */}
                                            </div>
                                        </div>
                                        <div className="oferta___tempo">
                                            <div className="ofertaFavorita">
                                                <h6>300 Centavos</h6>
                                                {/* <h6>{meusClassificados.idOfertasNavigation.Descricao}</h6> */}
                                            </div>
                                            <div className="tempoClass">
                                                <h5>99:59:59</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                {/* )
                            })} */}
                    </div>

                    
                </div>
            </div>
        )
    }

}
