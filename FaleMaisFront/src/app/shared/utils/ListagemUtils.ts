import { FormGroup } from "@angular/forms"

export class ListagemUtils {
    modalVisivel = false
    carregando = false
    form!: FormGroup

    constructor(){}

    carregamento(carregar:boolean): void {
        this.carregando = carregar
    }

    cancel(): void {
        this.form.reset()
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

    get editando():boolean{
        return this.form.get('id')?.value
    }
}