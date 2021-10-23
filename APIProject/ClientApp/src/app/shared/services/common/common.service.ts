import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { LockerService } from '../locker';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor(private _lockerService: LockerService, private _router: Router) { }

  private loadingPropertyChanged = new Subject<boolean>();    // handles the loader show/hide events
  private isLoggedInPropertyChanged = new Subject<any>();     // checks auth. accross different pages
  private loginPropertyChanged = new Subject<boolean>();      // checks if user already logged in
  // events that can be subscribe are written here

  isLoggedInPropertyChanged$: Observable<any> = this.isLoggedInPropertyChanged.asObservable();

  loadingPropertyChanged$: Observable<boolean> = this.loadingPropertyChanged.asObservable();

  loginPropertyChanged$: Observable<boolean> = this.loginPropertyChanged.asObservable();

  // show/hide loader
  showLoading(value) {
    this.loadingPropertyChanged.next(value)
  }

  // checks if user already logged in
  showLogin(value) {
    this.loginPropertyChanged.next(value)
  }

  onIsLoggedIn(value) {
    this.isLoggedInPropertyChanged.next(value)
  }


  /**
   * call this method to logout and clear session
   */
  clearLogoutHistory() {
    this._router.navigate(['/access/login']);
    this._lockerService.del('token');
    this._lockerService.del('user');
    this._lockerService.del('loggedInSession');
    this.onIsLoggedIn({ Status: false, Role: "" });
  }
}
