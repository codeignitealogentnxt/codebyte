import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-access',
  templateUrl: './access.template.html',
})
export class AccessTemplate implements OnInit {
  viewFooter:boolean =true;
  constructor() { }

  ngOnInit(): void {
  }

}
