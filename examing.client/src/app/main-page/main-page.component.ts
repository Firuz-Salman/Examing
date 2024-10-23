import { Component, OnInit } from '@angular/core';
import { MatDrawer, MatDrawerContainer, MatSidenavModule } from '@angular/material/sidenav';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MainPageService } from './main-page.service';
import { Subject, Subscription, takeUntil } from 'rxjs';
import { ExamViewModel, LessonViewModel, StudentViewModel } from '../../shared/api/all.types';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { LessonCreateDialogComponent } from './lesson-create-dialog/lesson-create-dialog.component';
import { StudentCreateDialogComponent } from './student-create-dialog/student-create-dialog.component';
import { ComponentType } from '@angular/cdk/overlay';
import { ExamCreateDialogComponent } from './exam-create-dialog/exam-create-dialog.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [
    MatDrawerContainer,
    MatButton,
    MatDrawer, MatSidenavModule, MatButtonModule, MatIcon, DatePipe,
  ],
  templateUrl: './main-page.component.html',
})
export class MainPageComponent implements OnInit {
  private _unsubscribeAll: Subject<any> = new Subject<any>();
  students: StudentViewModel[] = [];
  lessons: LessonViewModel[] = [];
  exams: ExamViewModel[] = [];

  show: 'lesson' | 'student' | 'exam' = 'lesson';


  constructor(private service: MainPageService, private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getExams();
    this.getLessons();
    this.getStudents();
  }


  getLessons() {
    console.log('she knows');
    this.service.getAllLessons().pipe(takeUntil(this._unsubscribeAll)).subscribe({
      next: value => {
        console.log(value);
        this.lessons = value;
      },
    });
  }

  getStudents() {
    this.service.getAllStudents().pipe(takeUntil(this._unsubscribeAll)).subscribe({
      next: value => {
        console.log(value);
        this.students = value;
      },
    });
  }

  getExams() {
    this.service.getAllExams().pipe(takeUntil(this._unsubscribeAll)).subscribe({
      next: value => {
        console.log(value);
        this.exams = value;
      },
    });
  }



  createLesson() {

    const dialog = this.dialog.open(LessonCreateDialogComponent, {
      width: '500px',
      disableClose: true,
      ariaLabel: 'Create Lesson',
    });

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.service.createLesson(result).pipe(takeUntil(this._unsubscribeAll)).subscribe({
          next: value => {
            console.log(value);
            this.ngOnInit();
          },
        });
      }
    });


  }

  createStudent() {

    const dialog = this.dialog.open(StudentCreateDialogComponent, {
      width: '500px',
      disableClose: true,
      ariaLabel: 'Create Student',
    });

    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.service.createStudent(result).pipe(takeUntil(this._unsubscribeAll)).subscribe({
          next: value => {
            console.log(value);
            this.ngOnInit();
          },
        });
      }
    });


  }

  createExam() {

    const dialog = this.dialog.open(ExamCreateDialogComponent, {
      width: '500px',
      disableClose: true,
      ariaLabel: 'Create Student',
    });

    dialog.componentInstance.students = this.students;
    dialog.componentInstance.lessons = this.lessons;
    dialog.afterClosed().subscribe(result => {
      if (result) {
        this.service.createExam(result).pipe(takeUntil(this._unsubscribeAll)).subscribe({
          next: value => {
            console.log(value);
            this.ngOnInit();
          },
        });
      }
    });


  }

  itemClicked(item: StudentViewModel | LessonViewModel | ExamViewModel) {
    console.log(item);
  }

  addNew() {
    if (this.show === 'lesson') {
      this.createLesson();
    } else if (this.show === 'student') {
      this.createStudent();
    } else if (this.show === 'exam') {
      this.createExam();
    }
  }


}
