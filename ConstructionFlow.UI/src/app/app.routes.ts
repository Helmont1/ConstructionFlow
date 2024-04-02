import { Routes } from '@angular/router';
import { HomeComponent } from '../_pages/home/home.component';
import { LoginComponent } from '../_pages/login/login.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent}
];
