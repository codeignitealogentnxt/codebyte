import { Component, OnInit } from '@angular/core';
import { LockerService, CommonService } from '../../services';
import { Router } from '@angular/router';
import { Configuration } from 'src/app/app.constants';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './index.html',
})
export class NavComponent implements OnInit {
  isLoggedIn: boolean = false;
  subscriptions: any[] = [];
  user: any;

  constructor(public _lockerService: LockerService, public _router: Router,
    private _config: Configuration,
    public _commonService: CommonService,
    private _toastr: ToastrService
  ) {

    this.subscriptions.push(_commonService.isLoggedInPropertyChanged$.subscribe(
      data => {
        if (data.Status) {
          this.isLoggedIn = data;
          this.user = JSON.parse(this._lockerService.get('user'));
        }
        else {
          this.isLoggedIn = false;
        }
      })
    );
  }

  ngOnInit() {
    if (this._lockerService.get('token')) {
      this.isLoggedIn = true
      this.user = JSON.parse(this._lockerService.get('user'));
    }
    else
      this.isLoggedIn = false;
  }

  onLogout() {
    this._commonService.clearLogoutHistory();
    this.showSuccess("You are logged out")
    this.isLoggedIn = false;
  }


  showSuccess(message) {
    this._toastr.clear();
    this._toastr.success('', message);
  }

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

}
