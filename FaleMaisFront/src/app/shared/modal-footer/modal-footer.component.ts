import { Component, EventEmitter, Input, Output } from '@angular/core'
import { FormGroup } from '@angular/forms'

@Component({
  selector: 'app-modal-footer',
  templateUrl: './modal-footer.component.html'
})
export class ModalFooterComponent {

  @Input() editando = false
  @Input() carregando = false
  @Input() form: FormGroup | undefined
  @Output() limparForm = new EventEmitter<MouseEvent>()
  @Output() cadastrarForm = new EventEmitter<boolean>()
  @Output() salvarForm = new EventEmitter<boolean>()

  constructor() { }

  limpar(evento: MouseEvent):void {
    this.limparForm.emit(evento)
  }

  cadastrar():void {
    this.cadastrarForm.emit(true)
  }

  salvar():void {
    this.salvarForm.emit(true)
  }
}
