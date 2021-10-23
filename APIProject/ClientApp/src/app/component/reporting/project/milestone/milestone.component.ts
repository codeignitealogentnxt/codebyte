import { ClientService } from '../../../../shared/services/client/client.service';
import { CommonService } from '../../../../shared/services/common/common.service';
import { Component, OnInit, Injector } from '@angular/core';
import { required, RxFormGroup } from '@rxweb/reactive-form-validators';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';
import { BsDatepickerDirective } from 'ngx-bootstrap/datepicker';
class MileStoneModel {
  @required()
  name: string;

  @required()
  plandate: string;

  @required() 
  actualdate: string;

  @required()
  comment: string;

}
@Component({
  selector: 'app-milestone',
  templateUrl: './milestone.component.html'
})
export class MilestoneComponent extends AppComponentBase implements OnInit {


  subscriptions: any[] = [];                      // stores all service subscription
  userRole: any;                                  // user role
  form: RxFormGroup;
  private model: MileStoneModel;
  constructor(injector: Injector,public _commonservice: CommonService,private _client:ClientService) { 
    super(injector);
  }

 /**
   * init view
   */
  ngOnInit() {
    this.model = new MileStoneModel();
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
    this._commonservice.showLoading(true);
      this.subscriptions.push(this._client.postclient(this.form.value).subscribe(
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
