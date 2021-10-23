import { ToastrService } from 'ngx-toastr';
import { LockerService } from './../services/locker/locker.service';
import { OnInit, Injector, OnDestroy, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { RxFormBuilder } from '@rxweb/reactive-form-validators';
import { Configuration } from 'src/app/app.constants';
export abstract class AppComponentBase implements OnInit, AfterViewInit, OnDestroy {
  fb: RxFormBuilder;
  config: Configuration
  generalFormErrors: string[];
  modalService: BsModalService;
  lockerService: LockerService;
  toastr: ToastrService
  myFormGroup: FormGroup;
  pageTitleSubscription: Subscription;
  title: string;
  route: ActivatedRoute;
  router: Router;
  state: 'loading' | 'ready' | 'error';

  @ViewChild('focus')
  focus: ElementRef;
  self: ElementRef;

  constructor(injector: Injector) {
    this.fb = injector.get(RxFormBuilder);
    this.modalService = injector.get(BsModalService);
    this.lockerService = injector.get(LockerService);
    this.config = injector.get(Configuration);
    this.toastr = injector.get(ToastrService);
    this.route = injector.get(ActivatedRoute);
    this.router = injector.get(Router);
    this.self = injector.get(ElementRef);
  }

  ngOnInit() {
    this.buildFormGroups();
  }

  ngAfterViewInit() {
    const firstInput = this.self.nativeElement.querySelector('input:not(readonly),select:not(readonly),textarea:not(readonly)');
    if (firstInput) {
      firstInput.focus();
    }
  }

  ngOnDestroy(): void {
    if (this.pageTitleSubscription) {
      this.pageTitleSubscription.unsubscribe();
    }
    this.closeAllModals();
  }

  abstract buildFormGroups();

  closeAllModals() {
    // TODO: may not need the following codes if migrating to AdlDialog instead of ngx-bootstrap
    let modalCount = this.modalService.getModalsCount();

    while (modalCount) {
      this.modalService.hide(modalCount);
      --modalCount;
    }
  }

  showSuccess(message) {
    this.toastr.clear();
    this.toastr.success(message);
  }
  showError(message) {
    this.toastr.clear();
    this.toastr.error(message);
  }

  get resolvedUrl() {
    return this.route.snapshot.pathFromRoot
      .map(v => v.url.map(segment => segment.toString()).join('/'))
      .join('/');
  }

}
