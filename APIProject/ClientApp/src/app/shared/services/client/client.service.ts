import { Injectable } from '@angular/core';
import { CommonService } from '../common';
import { Configuration } from 'src/app/app.constants';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private actionUrl: string;
  Isloggin: boolean;
  constructor(private http: HttpClient,
    private _config: Configuration, private _commonService: CommonService) {
    this.actionUrl = _config.ServerAPIUrl;
    this.handleError = this.handleError.bind(this);
  }


  /**
   * get 
   *
   */
  getCountry(): any {
    this._commonService.showLoading(true);
    return this.http.get(this.actionUrl + '/client/countries/')
      .pipe(map((response: Response) => { this.onSuccess(); return response }))
      .pipe(catchError(this.handleError));
  }

   /**
   * get 
   *
   */
  getallClient(): any {
    this._commonService.showLoading(true);
    return this.http.get(this.actionUrl + '/client/getallclient/')
      .pipe(map((response: Response) => { this.onSuccess(); return response }))
      .pipe(catchError(this.handleError));
  }

  /**
   * client for role
   * @param data
   */
  postclient(data):any {
    this._commonService.showLoading(true);
    return this.http.post(this.actionUrl + '/client/add', data)
    .pipe(map((response: Response) => { this.onSuccess(); return response }))
    .pipe(catchError(this.handleError));
  }

  
  private handleError(error: any) {
    this._commonService.showLoading(false);
    return throwError(error.json());
  }

  private onSuccess() {
    this._commonService.showLoading(false);
  }
}
