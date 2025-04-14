import { CustomerManageComponent } from './components/customer-manage/customer-manage.component';
import { Component, ViewChild } from '@angular/core';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CustomerService } from './customer.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-customer',
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    DatePipe
  ],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.scss',
})
export class CustomerComponent {
  columns: string[] = [
    'nomeRazao',
    'cpfcnpj',
    'email',
    'dataNascimento',
    'action',
  ];

  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog: MatDialog, private service: CustomerService) {}

  ngOnInit(): void {
    this.onLoadData();
  }

  onOpenAddDialog() {
    const dialogRef = this.dialog.open(CustomerManageComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.onLoadData();
        }
      },
    });
  }

  onLoadData() {
    this.service.getAll().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onDelete(id: number) {
    let confirm = window.confirm(
      'Tem certeza que deseja deletar este cliente?'
    );
    if (confirm) {
      this.service.delete(id).subscribe({
        next: (res) => {
          alert('Cliente deletado!');
          this.onLoadData();
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }

  onOpenEditForm(data: any) {
    const dialogRef = this.dialog.open(CustomerManageComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.onLoadData();
        }
      },
    });
  }
}
