import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RxReactiveFormsModule } from '@rxweb/reactive-form-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HRRoutingModule } from './hr-routing.module';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { UploadJDComponent } from './upload-jd-component';
import { FileUploadComponent } from './file-upload-component';
import { UploadService } from './upload.service';



@NgModule({
  declarations: [UploadJDComponent,FileUploadComponent],
  imports: [
    CommonModule,
    HRRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RxReactiveFormsModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ]
})
export class HRModule { }

