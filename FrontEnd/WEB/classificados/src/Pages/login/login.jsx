import { Component } from 'react';
import axios from 'axios';
import { link } from 'react-router-dom';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erro: '',
            isloading: false
        };
    };

    efetuarLogin = (event) => {
        event.preventDefault();

        this.setState({ erro: '', isloading: true });

        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);
                    this.setState({ isloading: false });

                    let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    console.log(base64);

                    console.log(parseJwt());

                    if (parseJwt().role == '1') {
                        this.props.history.push('/');
                        console.log('Logado com o Token: ' + usuarioAutenticado())
                    }

                    else{
                        this.props.history.push('/Login')
                    }
                }
            })

            .cath(() => {
                this.setState({erro: 'Email ou Senha inválidos!', isloading: false})
            })
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    };

    render(){
        return (
            <div>
                
            </div>
        )
    }
}