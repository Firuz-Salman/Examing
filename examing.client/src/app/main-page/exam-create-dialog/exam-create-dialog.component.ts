import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatHint, MatLabel, MatSuffix } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { ExamCreateModel, LessonViewModel, StudentViewModel } from '../../../shared/api/all.types';
import { MatOption, MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-exam-create-dialog',
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
    MatSelect,
    MatOption,
  ],
  templateUrl: './exam-create-dialog.component.html',
})
export class ExamCreateDialogComponent {
  students: StudentViewModel[] = [];
  lessons: LessonViewModel[] = [];
  exam: ExamCreateModel = {
    studentId: '',
    grade: 0,
    date: Date.now().toLocaleString(),
    lessonId: '',
  };

  constructor(public dialogRef: MatDialogRef<ExamCreateDialogComponent>) {
  }

  cancel() {
    this.dialogRef.close();
  }

  add() {
    if (this.exam.date !== '' &&
      this.exam.lessonId !== '' &&
      this.exam.grade !== 0 &&
      this.exam.studentId !== '') {

      this.dialogRef.close(this.exam);

    } else {
      alert('Məlumatlar doğru deyil və ya tam daxil edilməyib.');
    }
  }
}
