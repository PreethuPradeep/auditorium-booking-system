import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export const apiErrorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        alert('Please log in to continue.');
      } else if (error.status === 403) {
        alert('You are not authorized to access this.');
      } else if (error.status === 400) {
        alert(error.error?.error || 'Bad request.');
      } else {
        alert('Server error. Try again later.');
      }

      return throwError(() => error);
    })
  );
};
