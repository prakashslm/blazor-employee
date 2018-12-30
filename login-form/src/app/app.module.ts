import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

import {AppRoutingModule} from './app.routing';

import {AlertService} from './service/alert.service';
import {AuthenticationService} from './service/authentication.service';
import {UserService} from './service/user.service';
import { HomeComponent } from './home/home.component';
import { AlertComponent } from './directives/alert.component';

import {fakeBackendProvider} from './helpers/fakebackend';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [AlertService, AuthenticationService, UserService,fakeBackendProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
