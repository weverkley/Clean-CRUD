import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CustomerService } from '../../customer.service';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatRadioModule } from '@angular/material/radio';
import { MatOptionModule } from '@angular/material/core';
import { NgFor } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-customer-manage',
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatRadioModule,
    MatOptionModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    NgFor,
  ],
  templateUrl: './customer-manage.component.html',
  styleUrl: './customer-manage.component.scss',
})
export class CustomerManageComponent implements OnInit {
  form: FormGroup;

  constructor(
    private service: CustomerService,
    private dialogRef: MatDialogRef<CustomerManageComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.form = this.formBuilder.group({
      nomeRazao: ['', Validators.required],
      cpfcnpj: ['', Validators.required],
      email: ['', Validators.required],
      telefone: ['', Validators.required],
      dataNascimento: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.form.patchValue(this.data);
  }

  onSubmit() {
    if (this.form.valid) {
      if (this.data) {
        this.service.update(this.form.value).subscribe({
          next: (val: any) => {
            alert('Cliente atualizado com sucesso!');
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
            alert('Erro ao atualizar o cliente!');
          },
        });
      } else {
        this.service.add(this.form.value).subscribe({
          next: (val: any) => {
            alert('Cliente adicionado com sucesso!');
            this.form.reset();
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
            alert('Erro ao adicionar o cliente!');
          },
        });
      }
    }
  }
}
