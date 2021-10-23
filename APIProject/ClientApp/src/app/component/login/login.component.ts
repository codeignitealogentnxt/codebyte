import { Injector } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import {  AuthService, CommonService } from 'src/app/shared/services';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';
import { required, RxFormGroup } from '@rxweb/reactive-form-validators';


class LoginModel {
  @required()
  username: string;

  @required()
  password: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent extends AppComponentBase implements OnInit {
  subscriptions: any[] = [];                      // stores all service subscription
  userRole: any;                                  // user role
  form: RxFormGroup;
  private model: LoginModel;
  constructor(injector: Injector,public _authservice: AuthService, public _commonservice: CommonService) {
    super(injector);
  }

  
  /**
   * init view
   */
  ngOnInit() {
    this._commonservice.clearLogoutHistory();
    this.model = new LoginModel();
    super.ngOnInit();
  }

  buildFormGroups() {
    this.form = this.fb.formGroup(this.model) as RxFormGroup;
  }
  /**
    * Handles the Sign In request
    * @param  {FormGroup} value: loginForm
    */
  onSubmit() {
    this.form.submitted = true;
    if (this.form.valid) {
    this._commonservice.showLoading(true);
      this.subscriptions.push(this._authservice.getLoginInfo(this.form.value).subscribe(
        res => {
          console.log(res);
          if (res) {
            this.lockerService.set('token', res, this.config.TokenExpiryDays);;
            this.lockerService.set('loggedInSession', JSON.stringify(res), '')        
            this._commonservice.showLoading(false);
            this.router.navigate(['/user/reporting/dashboard'], { relativeTo: this.route });
            this.showSuccess('Success');
          } else {
            this._commonservice.showLoading(false);
            this.showError(res.message);
          }
        },
        err => {
          this.showError(err);
          this._commonservice.showLoading(false);
        }
      ));
    }
    }

    
  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
}
