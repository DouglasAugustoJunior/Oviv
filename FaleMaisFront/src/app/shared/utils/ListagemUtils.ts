import { FormGroup } from "@angular/forms"

export class ListagemUtils {
    modalVisivel = false
    form!: FormGroup

    constructor(){}

    cancel(): void {
        this.modalVisivel = false
    }

    limpar(evento: MouseEvent): void {
        evento.preventDefault()
        this.form.reset()
        for (const key in this.form.controls) {
            if (this.form.controls.hasOwnProperty(key)) {
                this.form.controls[key].markAsPristine()
                this.form.controls[key].updateValueAndValidity()
            }
        }
    }
}