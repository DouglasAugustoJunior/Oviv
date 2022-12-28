import { Component } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'

import { AutenticacaoService } from 'src/app/services/autenticacao.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent {
  validateForm!: FormGroup

  constructor(
    private autenticacaoService : AutenticacaoService,
    private fb: FormBuilder) {
    this.validateForm = this.fb.group({
      usuario: [null, [Validators.required,Validators.minLength(3), Validators.maxLength(100)]],
      senha: [null, [Validators.required,Validators.minLength(8), Validators.maxLength(12)]]
    })
  }

  enviarDados(): void {
    if (this.validateForm.valid)
      this.autenticacaoService.logar(this.validateForm.value).subscribe()
    else 
      destacarCamposInvalidos(this.validateForm)
  }

}
