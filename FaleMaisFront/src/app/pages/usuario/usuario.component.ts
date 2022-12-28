import { Component, OnInit } from '@angular/core'

import { UsuarioListagemDTO } from 'src/app/models/usuario-listagem-dto.model'
import { UsuarioService } from 'src/app/services/usuario.service'

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html'
})
export class UsuarioComponent implements OnInit {

  listaUsuarios: UsuarioListagemDTO[] = []

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.usuarioService
      .obterUsuarios()
      .subscribe(usuarios => this.listaUsuarios = usuarios)
  }

}
