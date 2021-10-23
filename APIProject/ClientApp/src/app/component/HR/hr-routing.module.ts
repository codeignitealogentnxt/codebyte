import { UploadJDComponent } from './upload-jd-component';
import { ScanResumesComponent } from './scan-resumes-component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: UploadJDComponent
  },
  {
    path: 'upload-jd',
    component: UploadJDComponent
  },
  {
    path: 'scan-resumes',
    component: ScanResumesComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HRRoutingModule { }
