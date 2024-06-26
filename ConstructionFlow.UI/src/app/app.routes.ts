import { HomeComponent } from '../_pages/home/home.component';
import { RegisterComponent } from '../_pages/register/register.component';
import { LoginComponent } from '../_pages/login/login.component';
import { ProfileComponent } from '../_pages/profile/profile.component';
import { ConstructionComponent } from '../_pages/construction/construction.component';
import { authGuard } from '../security/auth.guard';
import { Routes } from '@angular/router';
import { loginGuard } from '../security/login.guard';
import { FlowComponent } from '../_pages/flow/flow.component';
import { ConstructionAdminComponent } from '../_pages/construction-admin/construction-admin.component';

const isAuthenticaded: boolean = localStorage.getItem('isLoggedIn') == 'true';

export const routes: Routes = [
    { path: '', redirectTo: isAuthenticaded ? 'profile' : 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'register', component:RegisterComponent, canActivate: [loginGuard]},
    { path: 'login', component: LoginComponent, canActivate: [loginGuard]},
    { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
    { path: 'construction', component: ConstructionComponent, canActivate: [authGuard]},
    { path: 'flow', component: FlowComponent},
    { path: 'construction-admin/:id', component: ConstructionAdminComponent},
    { path: '**', redirectTo: isAuthenticaded ? 'profile' : 'home' }
];
