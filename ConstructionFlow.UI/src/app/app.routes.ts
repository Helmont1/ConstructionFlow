import { HomeComponent } from '../_pages/home/home.component';
import { RegisterComponent } from '../_pages/register/register.component';
import { LoginComponent } from '../_pages/login/login.component';
import { ProfileComponent } from '../_pages/profile/profile.component';
import { ConstructionComponent } from '../_pages/construction/construction.component';
import { authGuard } from '../security/auth.guard';
import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'register', component:RegisterComponent},
    { path: 'login', component: LoginComponent},
    { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
    { path: 'construction', component: ConstructionComponent, canActivate: [authGuard]},
    { path: '**', redirectTo: 'home' }
];
