import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BookingApiService } from '../../services/booking-api';
import { CommonModule } from '@angular/common';
import { CreateBookingRequest } from '../../models/booking.models';
import { ApiError } from '../../models/api-error.model';

@Component({
  selector: 'app-public-booking',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './public-booking.html',
  styleUrl: './public-booking.css',
})
export class PublicBooking {
  bookingId?: number;
  model: CreateBookingRequest = {
  name: '',
  phone: '',
  email: '',
  address1: '',
  address2: '',
  city: '',
  pincode: 0,
  startLocal: '',
  endLocal: '',
  eventType: ''
};
  constructor(private api: BookingApiService){}
  submit() {
  const payload = {
    ...this.model,
    pincode: Number(this.model.pincode),
    startLocal: new Date(this.model.startLocal).toISOString(),
    endLocal: new Date(this.model.endLocal).toISOString()
  };

  this.api.createBooking(payload).subscribe({
    next: res => {
      this.bookingId = res.bookingId;
      alert('Booking created successfully. Your booking ID is ' + this.bookingId);
    },
    error: (err:ApiError) => {
      if (err.validationErrors){
        console.log('Validation issues:', err.validationErrors);
        alert('Please fix form errors before submitting.');
      } else{
        alert(err.message);
      }
    }
  });
  }
}
