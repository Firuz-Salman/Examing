import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatHint, MatLabel, MatSuffix } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { StudentCreateModel } from '../../../shared/api/all.types';

@Component({
  selector: 'app-student-create-dialog',
  standalone: true,
  imports: [
    MatLabel,
    MatInput,
    MatIcon,
    MatSuffix,
    MatHint,
    MatFormField,
    FormsModule,
    MatButton,
  ],
  templateUrl: './student-create-dialog.component.html',
})
export class StudentCreateDialogComponent {
  student: StudentCreateModel = {
    studentNumber: 0,
    name: '',
    surname: '',
    class: 0,
  };

  constructor(public dialogRef: MatDialogRef<StudentCreateDialogComponent>) {
  }

  cancel() {
    this.dialogRef.close();
  }

  add() {
    if (this.student.studentNumber !== 0 &&
      this.student.name !== '' &&
      this.student.class  !== 0 &&
      this.student.surname !== '') {

      this.dialogRef.close(this.student);

    } else {
      alert('Məlumatlar doğru deyil və ya tam daxil edilməyib.');}
  }
}
