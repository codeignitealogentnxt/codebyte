import { CommonService } from './shared/services/common/common.service';
import { DEFAULT_ERROR_MESSAGES } from './app.constants';
import { Component } from '@angular/core';
import { ReactiveFormConfig, ErrorMessageBindingStrategy } from '@rxweb/reactive-form-validators';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'codeignite';
  isLoading: boolean;
  subscriptions: any[] = [];
constructor(private _commonService: CommonService){
  this.subscriptions.push(_commonService.loadingPropertyChanged$.subscribe(
    data => {
      this.isLoading = data;
    })
  );
}

public ngOnInit() {
ReactiveFormConfig.set({
  reactiveForm: {
     errorMessageBindingStrategy: ErrorMessageBindingStrategy.OnSubmit
  },
  validationMessage: DEFAULT_ERROR_MESSAGES
});
}

ngOnDestroy() {
  this.subscriptions.forEach(s => s.unsubscribe());
}
}