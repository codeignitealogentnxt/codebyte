/* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError,map } from 'rxjs/operators';
import { Configuration } from 'src/app/app.constants';
import { LockerService,CommonService } from 'src/app/shared/services';
@Injectable()
export class UploadService {
  protected basePath = '';
  private actionUrl: string;
  public defaultHeaders = new HttpHeaders();

  constructor(
    protected httpClient: HttpClient,
    private _config: Configuration, 
    public _lockerService: LockerService,
    private _commonService: CommonService
  ) {
    this.actionUrl = _config.ServerAPIUrl;
    this.handleError = this.handleError.bind(this);
  }

  public send(form: any): any{
    this._lockerService.set('isIgonre', true, 1);
    return this.httpClient
      .post(this.actionUrl + '/Upload', form)
      .pipe(map((response: Response) => { this.onSuccess(); return response }))
      .pipe(catchError(this.handleError));
  }

  public resumeSend(form: any): any{
    this._lockerService.set('isIgonre', true, 1);
    return this.httpClient
      .post(this.actionUrl + '/Resume/Upload', form)
      .pipe(map((response: Response) => { this.onSuccess(); return response }))
      .pipe(catchError(this.handleError));
  }

  private onSuccess() {
    this._lockerService.removeStorage('isIgonre');
    this._commonService.showLoading(false);
  }
  private handleError(error: any) {
    this._lockerService.removeStorage('isIgonre');
    this._commonService.showLoading(false);
    return throwError(error);
  }
}
