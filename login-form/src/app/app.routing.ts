import {NgModule}  from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';

const approutes : Routes = [
    {path : '', redirectTo: '/login', pathMatch : 'full'},
{path : 'login', component : LoginComponent},
{path : 'register', component : RegisterComponent}
];

@NgModule({
   imports : [RouterModule.forRoot(approutes)],
   exports : [RouterModule]
})
export class AppRoutingModule
{

}