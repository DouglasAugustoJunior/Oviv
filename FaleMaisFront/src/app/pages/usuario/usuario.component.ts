import { Component, OnInit } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'
import { NzModalService } from 'ng-zorro-antd/modal'
import { finalize } from 'rxjs/operators'

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
    private modalService: NzModalService,
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

  private obterUsuarios():void {
    this.carregamento(true)
    this.usuarioService
      .obterUsuarios()
      .pipe(finalize(() => this.carregamento(false)))
      .subscribe(usuarios => {
        this.listaUsuarios = usuarios
      })
  }

  showModal(usuario: UsuarioListagemDTO): void {
    this.form.patchValue(usuario)
    this.modalVisivel = true
  }

  modalCadastrar(): void {
    this.modalVisivel = true
  }

  cadastrar(): void {
    if(this.form.valid){
      this.carregamento(true)
      this.usuarioService.cadastrar(this.form.value)
        .pipe(finalize(() => this.carregamento(false)))
        .subscribe({
          next: () => {
            this.form.reset()
            this.obterUsuarios()
            this.modalVisivel = false
          }
        })
    }else
      destacarCamposInvalidos(this.form)
  }

  salvar(): void {
    if(this.form.valid){
      this.carregamento(true)
      this.usuarioService.atualizar(this.form.value)
        .pipe(finalize(() => this.carregamento(false)))
        .subscribe({
          next: () => {
            this.form.reset()
            this.obterUsuarios()
            this.modalVisivel = false
          }
        })
    }else
      destacarCamposInvalidos(this.form)
  }

  modalDeletar(usuario:UsuarioListagemDTO): void {
    this.modalService.create({
      nzTitle: 'Deletar',
      nzContent: `Deseja realmente excluir o usuário ${usuario.nome}?`,
      nzOkText: 'Excluir',
      nzCancelText: 'Cancelar',
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => this.deletar(usuario.id),
      nzOnCancel: () => this.cancel()
    })
  }

  deletar(id: number): void {
    this.usuarioService.deletar(id).subscribe(() => {
      this.obterUsuarios()
      this.modalVisivel = false
    })
  }

}
