import { CommonService } from '../../../../shared/services/common/common.service';
import { Component, OnInit, Injector } from '@angular/core';
import { required, RxFormGroup, email, prop } from '@rxweb/reactive-form-validators';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';
import { ProjectService } from 'src/app/shared/services/project/project.service';

class ProjectModel {
  @required()
  name: string;

  @required()
  resourcecount: number;

  @required() 
  billedresourcecount: number;

  @required()
  @email({message: 'Invalid email'})
  clientmanageremail: string;

  @required()
  @email({message: 'Invalid email'})
  accmanageremail: string;

  @required()
  @email({message: 'Invalid email'})
  promanageremail: string;
}

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
})
export class StartComponent extends AppComponentBase implements OnInit {

  subscriptions: any[] = [];                      // stores all service subscription
  userRole: any;                                  // user role
  form: RxFormGroup;
  private model: ProjectModel;
  constructor(injector: Injector,public _commonservice: CommonService,private _client:ProjectService) { 
    super(injector);
  }

 /**
   * init view
   */
  ngOnInit() {
    this.model = new ProjectModel();
    super.ngOnInit();
  }

  buildFormGroups() {
    this.form = this.fb.formGroup(this.model) as RxFormGroup;
  }
  /**
    * Handles the Sign In request
    * @param  {FormGroup} value: loginForm
    */
   onadd() {
    console.log(this.form);
    this.form.submitted = true;
    if (this.form.valid) {
      var request = {
        name : this.form.controls['name'].value,
        ClientId: 1,
        ReosurceCount: this.form.controls['resourcecount'].value,
        BilledResourceCount: this.form.controls['billedresourcecount'].value,
        ClientManagerEmail: this.form.controls['clientmanageremail'].value,
        AccountManagerEmail: this.form.controls['accmanageremail'].value,
        ProjectManagerEmail: this.form.controls['promanageremail'].value
       };
    this._commonservice.showLoading(true);
      this.subscriptions.push(this._client.postclient(request).subscribe(
        res => {
          if (res) {       
            this._commonservice.showLoading(false);
            this.showSuccess(res.message);
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
