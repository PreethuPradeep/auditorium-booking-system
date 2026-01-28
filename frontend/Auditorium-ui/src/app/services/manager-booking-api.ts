import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({ providedIn:'root'})
export class ManagerBookingApiService {
    private baseUrl = 'https://localhost:7298/api/manager/bookings';
    constructor(private http:HttpClient){}
    getByDate(date:string){
        return this.http.get<any[]>(`${this.baseUrl}?date=${date}`,{withCredentials:true});
    }
    approve(id:number){
        return this.http.post(`${this.baseUrl}/approve/${id}`,{}, {withCredentials:true});
    }
    reject(id:number){
        return this.http.post(`${this.baseUrl}/reject/${id}`,{}, {withCredentials:true});
    }
}