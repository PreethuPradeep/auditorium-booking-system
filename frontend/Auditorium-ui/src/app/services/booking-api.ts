import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { ApiBaseService } from './api-base.service';
import { CreateBookingRequest, CreateBookingResponse } from '../models/booking.models';

@Injectable({
  providedIn: 'root',
})
export class BookingApiService extends ApiBaseService{
  private baseUrl = `${environment.apiBaseUrl}/bookings`;

  createBooking(request: CreateBookingRequest):Observable<CreateBookingResponse>{
    return this.http.post<CreateBookingResponse>(this.baseUrl, request,{withCredentials:true})
    .pipe(catchError(this.handleError));
  }
  login(email:string,password:string):Observable<any>{
    return this.http.post(`${this.baseUrl}/auth/login`,{email,password},{withCredentials:true});
  }
  getBookingsByDay(date:string):Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}/bookings/day/${date}`,{withCredentials:true});
  }
  
}
