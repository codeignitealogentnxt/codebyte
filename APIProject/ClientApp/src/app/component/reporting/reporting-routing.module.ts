import { ListComponent } from './project/list/list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StartComponent } from './project/start/start.component';
import { MilestoneComponent } from './project/milestone/milestone.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  {
    path: 'add',
    component: StartComponent
  },
  {
    path: 'list',
    component: ListComponent
  },
  {
    path: 'milestone',
    component: MilestoneComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportingRoutingModule { }
