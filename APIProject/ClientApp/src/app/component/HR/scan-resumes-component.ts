import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProjectService } from 'src/app/shared/services';

@Component({
  selector: 'scan-resumes',
  templateUrl: './scan-resumes-component.html',
})
export class ScanResumesComponent implements OnInit {

  subscriptions: any[] = [];                      // stores all service subscription
  clientList:any=[];
  constructor(private _client:ProjectService,private toastr:ToastrService) { }

  ngOnInit() {
  
  }
 

  
    ngOnDestroy() {
  
  }
}