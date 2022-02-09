import { ValidatorFields } from './../../../helpers/ValidatorFields';
import { FormGroup, FormBuilder, AbstractControlOptions, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void{
    const formOptions: AbstractControlOptions = {
      validators: ValidatorFields.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group({
      titulo: ['', Validators.required],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
      descricao: ['', Validators.required],
      funcao: ['', Validators.required],
      senha: ['', [Validators.nullValidator, Validators.minLength(6)]],
      confirmeSenha: ['', Validators.nullValidator],
    }, formOptions);
  }

  get f(): any {return this.form.controls; }

  onSubmit(): void{
    if (this.form.invalid){
      return;
    }
  }

  public resetForm(event:any): void{
    event.preventDefault();
    this.form.reset();
  }

}
