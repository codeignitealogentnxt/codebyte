import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProjectService } from 'src/app/shared/services';

@Component({
  selector: 'upload-jd',
  templateUrl: './upload-jd-component.html',
})
export class UploadJDComponent implements OnInit {

  subscriptions: any[] = [];                      // stores all service subscription
  clientList:any=[];
  constructor(private _client:ProjectService,private toastr:ToastrService) { }

  ngOnInit() {
  
  }
 

  
    ngOnDestroy() {
  
  }
}