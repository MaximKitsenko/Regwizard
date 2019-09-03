import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-step1-component',
  templateUrl: './step1.component.html',
  template: `
    <div class="form-group">
          <label for="login">login:</label>
          <input type="email" name="login" (ngModelChange)="validateLogin($event)" id="login" [(ngModel)]="login" placeholder="login">
          <div *ngIf="loginMeta.invalid"
               class="alert alert-danger">

            <div *ngIf="loginMeta.errors.required">
              Name is required.
            </div>
            <div *ngIf="loginMeta.errors.isNotMail">
              Login must be a correct mail.
            </div>
          </div>
    </div>
    <div class="form-group">
      <label for="password">password:</label>
      <input type="password" name="password" id="password" [(ngModel)]="password" placeholder="password">
    </div>
    <div class="form-group">
      <label for="confirmPassword">password:</label>
      <input type="password" name="confirmPassword" id="confirmPassword" [(ngModel)]="confirmPassword" placeholder="confirm password">
    </div>
    <div class="form-group">
      <label for="agree">agree:</label>
      <input type="checkbox" name="agree" id="agree" [(ngModel)]="agree" >
    </div>
    <div class="form-group">
      <input type="button" (click)="validateLogin()" name="next" id="next" value="Next" >
    </div>
    <h1> {{login}}!{{password}}!{{confirmPassword}}!{{agree}}!{{loginMeta.invalid}}</h1>`
})
export class Step1Component {
  @Input()
  bankName: string;
  @Input('account-id')
  id: string;
  public login = '';
  public loginMeta = {
    invalid: false,
    errors: { required: false, isNotMail: true }
  };

  public password = '';
  public confirmPassword = '';
  public agree = false;

  //w3c email validator, doesn't work
  private loginValidator = new RegExp("/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/");
  //https://stackoverflow.com/questions/46155/how-to-validate-an-email-address-in-javascript
  private loginValidatorSo = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^ <>() \[\]\\.,;: \s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  public validateLogin(e) {
    if (!this.login) {
      this.loginMeta.invalid = true;
      this.loginMeta.errors.required = true;
      return;
    }
    if (!this.loginValidatorSo.test(this.login)) {
      //todo: have no time to investigate how validators wor out from the box
      this.loginMeta.invalid = true;
      return;
    }

    //todo: have no time to investigate how validators wor out from the box
    this.loginMeta.invalid = false;
    this.loginMeta.errors.required = false;
  }
}
