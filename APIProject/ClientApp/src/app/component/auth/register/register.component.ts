import { Injector } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import {  AuthService, CommonService } from 'src/app/shared/services';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';
import { required, RxFormGroup, email,compare } from '@rxweb/reactive-form-validators';


class RegisterModel {
  @required()
  username: string;

  @required()
  firstname: string;

  @required()
  lastname: string;

  @required()
  @email({message: 'Invalid email'})
  email: string;

  @required()
  password: string;

  @required()
  @compare({ fieldName: 'password', message: 'Your passwords do not match' })
  confirmpassword: string;
}


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent extends AppComponentBase implements OnInit {
  subscriptions: any[] = [];                      // stores all service subscription
  userRole: any;                                  // user role
  form: RxFormGroup;
  private model: RegisterModel;
  constructor(injector: Injector,public _authservice: AuthService,public _commonservice: CommonService) { 
    super(injector);
  }

/**
   * init view
   */
  ngOnInit() {
    this.model = new RegisterModel();
    super.ngOnInit();
  }

  buildFormGroups() {
    this.form = this.fb.formGroup(this.model) as RxFormGroup;
  }
  /**
    * Handles the Sign In request
    * @param  {FormGroup} value: loginForm
    */
   onRegister() {
    this.form.submitted = true;
    if (this.form.valid) {
      const postregister ={
        UserName:this.model.username,
        Password:this.model.password,
        FirstName:this.model.firstname,
        LastName:this.model.lastname,
        Email:this.model.email,
      }
    this._commonservice.showLoading(true);
      this.subscriptions.push(this._authservice.postregister(postregister).subscribe(
        res => {
          if (res) {        
            this._commonservice.showLoading(false);
            this.showSuccess('Success');
            this.router.navigate(['/user/reporting/dashboard'], { relativeTo: this.route });
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
