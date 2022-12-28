import { FormGroup } from "@angular/forms"

export function destacarCamposInvalidos(formulario: FormGroup):void {
    Object
        .values(formulario.controls)
        .forEach(control => {
            if (control.invalid) {
                control.markAsDirty()
                control.updateValueAndValidity({ onlySelf: true })
            }
        })
}