import { Component } from '@angular/core';
import { ManagerBookingApiService } from '../../services/manager-booking-api';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-manager-booking',
  imports: [CommonModule,FormsModule],
  templateUrl: './manager-booking.html',
  styleUrl: './manager-booking.css',
})
export class ManagerBooking {
  selectedDate = '';
  bookings:any[] = [];
  
  constructor(private api:ManagerBookingApiService) {}
  load(){
    this.api.getByDate(this.selectedDate)
    .subscribe(res => this.bookings = res);
  }
  approve(id:number){
    this.api.approve(id)
    .subscribe(() => this.load());
  }
  reject(id:number){
    this.api.reject(id)
    .subscribe(() => this.load());
  }
}
