import React, { Component } from 'react';
import Moment from 'moment';

export class GitHubDetalhe extends Component {
    static displayName = GitHubDetalhe.name;

    constructor(props) {
        super(props);

        this.state = {
            id: props.location.idPropos,
            loading: true,
            gitHub: {}
        };
    }

    componentDidMount() {
        if (this.state.id > 0) {
            this.detalharGitHub();
        }
        else {
            this.props.history.push("/");
        }
    }

    async detalharGitHub() {
        const response = await fetch(`api/github/${this.state.id}`);
        const data = await response.json();
        this.setState({ gitHub: data.data, loading: false });
    }

    render() {
        return (
            <>
                <h1 id="tabelLabel" >Detalhe Repositório</h1>
                <p>Nome:&nbsp;{this.state.gitHub.nome}</p>
                <p>Descrição:&nbsp;{this.state.gitHub.descricao}</p>
                <p>Linguagem:&nbsp;{this.state.gitHub.linguagem}</p>
                <p>Data Atualização:&nbsp;{Moment(this.state.gitHub.dtAtualizacao).format('DD/MM/YYYY')}</p>
                <p>Dono repositório: &nbsp;{this.state.gitHub.donoRepositorio}</p>

                <div class="row">
                    <div class="col-md-12 bg-light text-right">
                        <button type="button" onClick={() => this.props.history.push('/')} class="btn btn-primary">Voltar</button>
                    </div>
                </div>
            </>
        );
    }
}
