import { ProjectService } from './services/project/project.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { LockerService, CommonService, AuthService, ClientService } from './services/index';
import { AppHttpInterceptor } from './interceptor/app.http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [],
  exports: [CommonModule]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [{
        provide: HTTP_INTERCEPTORS,
        useClass: AppHttpInterceptor,
        multi: true
      },  LockerService, CommonService, AuthService,ProjectService,ClientService]
    }
  }
}
