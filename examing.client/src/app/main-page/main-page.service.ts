import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  ExamCreateModel,
  ExamViewModel,
  LessonCreateModel,
  LessonViewModel,
  StudentCreateModel,
  StudentViewModel,
} from '../../shared/api/all.types';

@Injectable({providedIn: 'root'})
export class MainPageService {

  baseUrl: string = 'http://localhost:5243/api';

  constructor(private http: HttpClient) {

  }


  getAllLessons(): Observable<LessonViewModel[]> {
    const url = `${this.baseUrl}/lesson`;

    return this.http.get<LessonViewModel[]>(url);
  }
  getAllStudents(): Observable<StudentViewModel[]> {
    const url = `${this.baseUrl}/student`;

    return this.http.get<StudentViewModel[]>(url);
  }
  getAllExams(): Observable<ExamViewModel[]> {
    const url = `${this.baseUrl}/exam`;

    return this.http.get<ExamViewModel[]>(url);
  }


  createLesson(body : LessonCreateModel) : Observable<LessonViewModel> {
    const url = `${this.baseUrl}/lesson`;

   return  this.http.post<LessonViewModel>(url, body);
  }

  createStudent(body : StudentCreateModel) : Observable<StudentViewModel> {
    const url = `${this.baseUrl}/student`;

    return  this.http.post<StudentViewModel>(url, body);
  }

  createExam(body : ExamCreateModel) : Observable<ExamViewModel> {
    const url = `${this.baseUrl}/exam`;

    return this.http.post<ExamViewModel>(url, body);
  }
}
