import { ToastrService } from 'ngx-toastr';
import { ClientService } from './../../../shared/services/client/client.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  subscriptions: any[] = [];                      // stores all service subscription
  clientList:any=[];
  constructor(private _client:ClientService,private toastr:ToastrService) { }

  ngOnInit() {
    this.getallClient();
  }
  getallClient(){
    this.subscriptions.push(this._client.getallClient().subscribe(
      res => {
        this.clientList = [];
         if (res) {
              this.clientList = res;  
            } else {
              this.showError({ 'message': 'Failed' });
            }
          },
          err => {
            this.showError({ 'message': err.statusText });
          }
        ));  
  }

  
  showSuccess(message) {
    this.toastr.clear();
    this.toastr.success(message);
  }
  showError(message) {
    this.toastr.clear();
    this.toastr.error(message);
  }

    ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }
}
