import React, { Component } from 'react';
import { StarFill, Star } from 'react-bootstrap-icons';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class GitHub extends Component {
    static displayName = GitHub.name;

    constructor(props) {
        super(props);
        this.state = {
            gitHubs: [],
            loading: true,
            usuario: 'viniciustes',
            filtroNome: '',
            gitHubsFiltered: [],
        };

        this.handleChangeUsuario = this.handleChangeUsuario.bind(this);
        this.handleChangeFiltroNome = this.handleChangeFiltroNome.bind(this);
        this.populateGitHubDB = this.populateGitHubDB.bind(this);
        this.handleClickFavorito = this.handleClickFavorito.bind(this);
    }

    componentDidMount() {
        this.populateGitHub();
    }

    async handleChangeFiltroNome(event) {
        this.setState({
            filtroNome: event.target.value,
            gitHubs: this.state.gitHubsFiltered.filter(x => x.nome.toLowerCase().includes(this.state.filtroNome.toLowerCase()))
        });
    }

    handleChangeUsuario(event) {
        this.setState({ usuario: event.target.value });
    }

    async handleClickFavorito(id) {
        await fetch(`api/github/${id}`, { method: 'post' });

        this.populateGitHub();
    }

    async populateGitHub() {
        const response = await fetch('api/github');
        const data = await response.json();
        this.setState({
            gitHubs: data.data,
            loading: false,
            gitHubsFiltered: data.data
        });
    }

    async populateGitHubDB() {
        this.setState({ loading: true });
        await fetch(`api/github/${this.state.usuario}`);
        this.populateGitHub();
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >GitHub</h1>
                <p>Demostração de repositórios GitHub.</p>
                <p>Projeto criado como proposta de desafio para vaga de desenvolvedor ao banco Sofisa</p>
                <label for="fusuario">Usuário GitHub:</label>
                  &nbsp;
                <input type="text"
                    placeholder="Usuário"
                    style={{ border: 0 }}
                    value={this.state.usuario}
                    onChange={this.handleChangeUsuario}
                />
                &nbsp;
                <button className="btn btn-primary" onClick={this.populateGitHubDB}>Pesquisar Repositório</button>
                <br />
                <br />
                <br />
                <br />
                <div>
                    {this.state.loading && <p><em>Loading...</em></p>}
                    {!this.state.loading &&
                        <div>
                            {this.state.gitHubs.length > 0 &&
                                <div>
                                    <div class="row">
                                        <div class="col-md-12 bg-light text-right">
                                            <input type="text"
                                                style={{ border: 0 }}
                                                placeholder="Pesquisar"
                                                value={this.state.filtroNome}
                                                onChange={this.handleChangeFiltroNome}
                                            />
                                        </div>
                                    </div>
                                    <table className='table table-striped' aria-labelledby="tabelLabel">
                                        <thead>
                                            <tr>
                                                <th>Nome</th>
                                                <th>Descrição</th>
                                                <th>Favorito</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {this.state.gitHubs.map(git =>
                                                <tr key={git.id}>
                                                    <td>
                                                        <NavLink tag={Link} className="text-dark" to={{ pathname: '/git-hub-detalhe', idPropos: git.id }} >{git.nome}</NavLink>
                                                    </td>
                                                    <td>{git.descricao}</td>
                                                    {!git.favorito && <td><Star onClick={() => this.handleClickFavorito(git.id)} className="ml-4" /></td>}
                                                    {git.favorito && <td><StarFill onClick={() => this.handleClickFavorito(git.id)} className="ml-4" /></td>}
                                                </tr>
                                            )}
                                        </tbody>
                                    </table>
                                </div>}
                        </div>
                    }
                </div>
            </div>
        );
    }
}