import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RxReactiveFormsModule } from '@rxweb/reactive-form-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ReportingRoutingModule } from './reporting-routing.module';
import { StartComponent } from './project/start/start.component';
import { ListComponent } from './project/list/list.component';
import { MilestoneComponent } from './project/milestone/milestone.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [StartComponent, ListComponent, MilestoneComponent, DashboardComponent],
  imports: [
    CommonModule,
    ReportingRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RxReactiveFormsModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
  ]
})
export class ReportingModule { }
