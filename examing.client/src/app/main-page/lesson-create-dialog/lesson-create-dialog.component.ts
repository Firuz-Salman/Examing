import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatHint, MatLabel, MatSuffix } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { LessonCreateModel } from '../../../shared/api/all.types';

@Component({
  selector: 'app-lesson-create-dialog',
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
  templateUrl: './lesson-create-dialog.component.html',
})
export class LessonCreateDialogComponent {
  lesson: LessonCreateModel = {
    name: '',
    code: '',
    class: 0,
    teacherName: '',
    teacherSurname: '',
  };

  constructor(public dialogRef: MatDialogRef<LessonCreateDialogComponent>) {
  }

  cancel() {
    this.dialogRef.close();
  }

  add() {
    if (this.lesson.code !== '' &&
      this.lesson.name !== '' &&
      this.lesson.teacherName !== '' &&
      this.lesson.teacherSurname !== '' &&
      this.lesson.class !== 0 ) {

      this.dialogRef.close(this.lesson);

    } else {
      alert('Məlumatlar doğru deyil və ya tam daxil edilməyib.');}
  }
}
