import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RxReactiveFormsModule } from '@rxweb/reactive-form-validators';


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,    
    LoginRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RxReactiveFormsModule
  ]
})
export class LoginModule {}
