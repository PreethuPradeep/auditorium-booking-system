import { Routes } from '@angular/router';
import { PublicBooking } from './components/public-booking/public-booking';
import { ManagerBooking } from './components/manager-booking/manager-booking';

export const routes: Routes = [
  { path: 'booking', component: PublicBooking },
  { path: 'manager-booking', component: ManagerBooking }
];