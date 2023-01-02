import { Component, OnInit } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'

import { UsuarioListagemDTO } from 'src/app/models/usuario-listagem-dto.model'
import { UsuarioService } from 'src/app/services/usuario.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'
import { IListagemUtils } from 'src/app/shared/utils/IListagemUtils'
import { ListagemUtils } from 'src/app/shared/utils/ListagemUtils'

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html'
})
export class UsuarioComponent  extends ListagemUtils implements IListagemUtils, OnInit {

  listaUsuarios: UsuarioListagemDTO[] = []

  constructor(
    private fb:FormBuilder,
    private usuarioService: UsuarioService) {
    super()
    this.form = this.fb.group({
      id: [null, []],
      nome: [null, [ Validators.required, Validators.minLength(3), Validators.maxLength(100) ]],
      senha: [null, [ Validators.required , Validators.minLength(8), Validators.maxLength(12)]],
      autorizacao: ['', [ Validators.required ]]
    })
  }

  ngOnInit(): void {
    this.obterUsuarios()
  }

  private obterUsuarios() {
    this.usuarioService
      .obterUsuarios()
      .subscribe(usuarios => this.listaUsuarios = usuarios)
  }

  showModal(usuario: UsuarioListagemDTO): void {
    this.form.patchValue(usuario)
    this.modalVisivel = true
  }

  ok(): void {
    if(this.form.valid){
      this.usuarioService.atualizar(this.form.value).subscribe(() => {
        this.obterUsuarios()
        this.modalVisivel = false
      })
    }else
      destacarCamposInvalidos(this.form)
  }

}
