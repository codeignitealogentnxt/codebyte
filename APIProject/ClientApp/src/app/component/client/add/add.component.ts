import { ClientService } from './../../../shared/services/client/client.service';
import { CommonService } from './../../../shared/services/common/common.service';
import { Component, OnInit, Injector } from '@angular/core';
import { required, RxFormGroup, email, prop } from '@rxweb/reactive-form-validators';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';

class ClientModel {
  @required()
  name: string;

  @required()
  domain: string;

  @required()
  @email({message: 'Invalid email'})
  email: string;

  @required()
  phone: string;

  @required()
  countryId: string;

  @required()
  address1: string;

  @required()
  city: string;

  @required()
  state: string;

  @required()
  pincode: string;

  @prop()
  address2: string;
}



@Component({
  selector: 'app-add',
  templateUrl: './add.component.html'
})
export class AddComponent extends AppComponentBase implements OnInit {
  subscriptions: any[] = [];                      // stores all service subscription
  userRole: any;                                  // user role
  form: RxFormGroup;
  private model: ClientModel;
  countryList:any;
  constructor(injector: Injector,public _commonservice: CommonService,private _client:ClientService) { 
    super(injector);
  }

 /**
   * init view
   */
  ngOnInit() {
    this.model = new ClientModel();
    this.getCountry()
    super.ngOnInit();
  }

  buildFormGroups() {
    this.form = this.fb.formGroup(this.model) as RxFormGroup;
  }

  getCountry(){
    this.subscriptions.push(this._client.getCountry().subscribe(
      res => {
        this.countryList = [];
         if (res) {
              this.countryList = res;  
            } else {
              this.showError({ 'message': 'Failed' });
            }
          },
          err => {
            this.showError({ 'message': err.statusText });
          }
        ));  
  }

  /**
    * Handles the Sign In request
    * @param  {FormGroup} value: loginForm
    */
   onadd() {
    this.form.submitted = true;
    if (this.form.valid) {
      const postclient ={
        Name:this.model.name,
        Domain:this.model.domain,
        Email:this.model.email,
        Phone:this.model.phone,
        Address1:this.model.address1,
        Address2:this.model.address2,
        City:this.model.city,
        State:this.model.state,
        Pin:this.model.pincode,
        CountryId: this.model.countryId
      }
    this._commonservice.showLoading(true);
      this.subscriptions.push(this._client.postclient(postclient).subscribe(
        res => {
          if (res) {       
            this._commonservice.showLoading(false);
            this.showSuccess('Success');
            this.router.navigate(['/user/client/list'], { relativeTo: this.route });
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
