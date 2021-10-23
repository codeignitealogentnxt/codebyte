import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ProjectService } from 'src/app/shared/services';

@Component({
  selector: 'upload-jd',
  templateUrl: './upload-jd-component.html',
})
export class UploadJDComponent implements OnInit {

  subscriptions: any[] = [];                      // stores all service subscription
  clientList:any=[];
  constructor(private _client:ProjectService,private toastr:ToastrService,private http: HttpClient) { }

  ngOnInit() {
  
  }
 

  
    ngOnDestroy() {
  
  }

  
  requiredFileType:string=".docx";

  fileName = '';
  uploadProgress:number;
  uploadSub: Subscription;

  

  onFileSelected(event) {
      const file:File = event.target.files[0];
    
      if (file) {
          this.fileName = file.name;
          const formData = new FormData();
          formData.append("thumbnail", file);

          const upload$ = this.http.post("/api/thumbnail-upload", formData, {
              reportProgress: true,
              observe: 'events'
          })
          .pipe(
              finalize(() => this.reset())
          );
        
          this.uploadSub = upload$.subscribe(event => {
            if (event.type == HttpEventType.UploadProgress) {
              this.uploadProgress = Math.round(100 * (event.loaded / event.total));
            }
          })
      }
  }

cancelUpload() {
  this.uploadSub.unsubscribe();
  this.reset();
}

reset() {
  this.uploadProgress = null;
  this.uploadSub = null;
}
}