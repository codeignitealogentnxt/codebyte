
import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from 'src/app/shared/app-component-base/app-component-base';
import { HttpEventType } from '@angular/common/http';
import { UploadService } from './upload.service';
import { LockerService } from 'src/app/shared/services';

@Component({
  selector: 'app-job-description',
  templateUrl: './job-description.component.html',
  styleUrls: ['./job-description.component.scss']
})
export class JobDesComponent extends AppComponentBase implements OnInit {
  subscriptions: any[] = [];                      // stores all service subscription
  attachments: FileList;
  showFileSizeValidation: boolean = false;
  public progress: number;
  constructor(injector: Injector,  private uploadService: UploadService,
    private _lockerService:LockerService) {
    super(injector);
  }

  /**
    * init view
    */
  ngOnInit() {
    super.ngOnInit();
  }

  buildFormGroups() {
  }

  uploadFiles(files): void {
    if (files.length) {
      this.attachments = files;
      this.showFileSizeValidation = this.getFilesSize(files);
    }
  }

  /**
    * Handles the Sign In request
    * @param  {FormGroup} value: loginForm
    */
  onadd() {
    if (this.attachments) {
      const formData = new FormData();
      if (this.attachments) {
        for (let i = 0; i < this.attachments.length; i++) {
          console.log(this.attachments[i])
          formData.append('file', this.attachments[i]);
        }
      }
      //this._commonservice.showLoading(true);
      this.subscriptions.push(this.uploadService.send(formData).subscribe(
        res => {
          this._lockerService.removeStorage('isIgonre');
        if (res.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * res.loaded / res.total);
          if (res) {
            //this._commonservice.showLoading(false);
            this.showSuccess('Success');
          } 
        },
        err => {
          this._lockerService.removeStorage('isIgonre');
          this.showError(err);
          //this._commonservice.showLoading(false);
        }
      ));
    }
  }

  private getFilesSize(files: FileList): boolean {
    let totalSize = 0;
    for (let i = 0; i <= files.length - 1; i++) {
      totalSize += files[i].size;
    }
    return totalSize > 1024 * 1024 * 20;
  }
  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

}
