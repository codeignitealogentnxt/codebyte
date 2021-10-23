import { AuthGuard } from './shared/auth.guard';
import { AccessTemplate } from './templates/access/access.template';
import { NotFoundComponent } from './component/common/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Maintemplate } from './templates/main/main.template';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'user/reporting/dashboard',
    pathMatch: 'full',
  },
  {
    path: 'access',
    component: AccessTemplate,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      {
        path: 'login',
        loadChildren: () => import('./component/login/login.module').then(m => m.LoginModule)
      },
    ]
  },
  {
    path: 'user',
    component: Maintemplate,
   canActivate: [AuthGuard],
    runGuardsAndResolvers: 'always',
    children: [
      { path: '', redirectTo: 'client', pathMatch: 'full' },
      {
        path: 'client',
        loadChildren: () => import('./component/client/client.module').then(m => m.ClientModule)
      },
      {
        path: 'reporting',
        loadChildren: () => import('./component/reporting/reporting.module').then(m => m.ReportingModule)
      },
      {
        path: 'register',
        loadChildren: () => import('./component/auth/Auth.module').then(m => m.AuthModule)
      },
    ],
  },
  {
    path: 'hr',
    component: Maintemplate,
   canActivate: [AuthGuard],
    runGuardsAndResolvers: 'always',
    children: [
      { path: '', redirectTo: 'hr-mgmt', pathMatch: 'full' },
      {
        path: 'hr-mgmt',
        loadChildren: () => import('./component/HR/hr.module').then(m => m.HRModule)
      }     
    ],
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
