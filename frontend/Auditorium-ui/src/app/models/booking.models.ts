export interface CreateBookingRequest {
  name: string;
  phone: string;
  email: string;
  address1: string;
  address2: string;
  city: string;
  pincode: number;
  startLocal: string; // ISO
  endLocal: string;   // ISO
  eventType: string;
}
export interface CreateBookingResponse{
  bookingId:number;
}
