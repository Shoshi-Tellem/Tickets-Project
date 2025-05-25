import { Routes } from '@angular/router';
import { LoginComponent } from '../components/login/login.component';
import { HeaderComponent } from '../components/header/header.component';
import { HomeComponent } from '../components/home/home.component';
import { SignUpComponent } from '../components/sign-up/sign-up.component';
import { TicketComponent } from '../components/ticket/ticket.component';
import { ShowTicketComponent } from '../components/show-ticket/show-ticket.component';

export const routes: Routes = [
    {
        path: '', component: HeaderComponent, children: [
            { path: 'home', component: HomeComponent },
            { path: 'login', component: LoginComponent },
            { path: 'signup', component: SignUpComponent },
            { path: 'add-ticket', component: TicketComponent },
            { path: 'show-ticket', component: ShowTicketComponent }
        ]
    }
];
