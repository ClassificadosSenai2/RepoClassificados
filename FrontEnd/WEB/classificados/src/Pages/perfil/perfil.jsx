import '../../Assets/css/styles.css'
import Header from "../../Components/header.jsx"

import { Component } from "react";

export default class Perfil extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nome: '',
            sobrenome: '',
            email: '',
            ddd: 0,
            telefone: 0
        }
    };

    render() {
        return (
            <div>
                Perfil
            </div>

        )
    }
}