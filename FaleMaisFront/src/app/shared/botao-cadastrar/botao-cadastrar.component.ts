import { Component, EventEmitter, Output } from '@angular/core'

@Component({
  selector: 'app-botao-cadastrar',
  templateUrl: './botao-cadastrar.component.html'
})
export class BotaoCadastrarComponent {
  @Output() abrirModal = new EventEmitter<boolean>()

  constructor() { }

  modalCadastrar():void {
    this.abrirModal.emit(true)
  }

}
