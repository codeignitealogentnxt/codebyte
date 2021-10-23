import { NavComponent } from './shared/layout/nav/nav.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { Configuration } from './app.constants';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotFoundComponent } from './component/common/not-found/not-found.component';
import { Maintemplate } from './templates/main/main.template';
import { AccessTemplate } from './templates/access/access.template';
import {UploadService} from './component/HR/upload.service'
@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    AccessTemplate,
    Maintemplate,
    NavComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule.forRoot(),
    ModalModule.forRoot(),
    AppRoutingModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-top-center',
      preventDuplicates: true,
    }),
  ],
  providers: [Configuration,UploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
