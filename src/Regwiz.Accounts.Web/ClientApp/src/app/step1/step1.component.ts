import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-step1-component',
  templateUrl: './step1.component.html',
  template: `
    Bank Name: {{bankName}}
    Account Id: {{id}}
  `
})
export class Step1Component {
  @Input() bankName: string;
  @Input('account-id') id: string;
  public login = '';
  public password = '';
  public confirmPassword = '';
  public agree = '';

  public incrementCounter() {
    this.login = "asd";
  }
}
