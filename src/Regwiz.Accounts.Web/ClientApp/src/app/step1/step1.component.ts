import { Component, Input, Inject } from '@angular/core';
//import { FormBuilder, FormGroup } from '@angular/forms';
//import { MatInputModule, MatFormFieldModule } from '@angular/material';
import { HttpClient } from '@angular/common/http';

export interface Country {
  value: string;
  viewValue: string;
  id: string;
  name: string;
}

export interface Province {
  id: number;
  countryId: number;
  name: string;
}

@Component({
  selector: 'app-step1-component',
  templateUrl: './step1.component.html',
  template: `
    <div class="step1" [ngClass]="{invisible: step2}" >
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
        <input type="button" (click)="goNext()" name="next" id="next" value="Next" >
      </div>
    </div>
    <div class="step1" [ngClass]="{invisible: !step2}" >
      <form (ngSubmit)="submit()">
        <label for="countries">Country</label>
        <select id="countries" [(ngModel)]="selectedCountry" (change)="pullProvince($event)"  >
          <option *ngFor="let country of countries; let i = index" [value]="countries[i].id">
            {{countries[i].name}}
          </option>
        </select>

        <label for="provinces">Province</label>
        <select id="province" [(ngModel)]="selectedProvince">
          <option *ngFor="let province of provinces; let i = index" [value]="provinces[i].id" >
            {{provinces[i].name}}
          </option>
        </select>
        <button>submit</button>
      </form>
    </div>

    <h1> {{!this.loginMeta.invalid }} && {{ !this.passwordMeta.invalid }} && {{this.agree}} && {{this.selectedCountry}} && {{this.selectedProvince}}</h1>`,
  styles: [`.invisible{display:none;}`]
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
  public passwordMeta = {
    invalid: false,
    errors: { required: false, }
  };
  public confirmPassword = '';
  public confirmPasswordMeta = {
    invalid: false,
    errors: { required: false, }
  };
  public agree = false;
  public countries: Country[];
  public provinces: Province[];
  public selectedCountry: 1;
  public selectedProvince: 1;
  public baseUrl: string;
  public httpClient: HttpClient;

  //w3c email validator, doesn't work
  private loginValidator = new RegExp("/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/");
  //https://stackoverflow.com/questions/46155/how-to-validate-an-email-address-in-javascript
  private loginValidatorSo = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^ <>() \[\]\\.,;: \s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  step2: boolean = true;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.httpClient = http;
    http.get<Country[]>(baseUrl + 'api/SampleData/Countries').subscribe(result => {
      this.countries = result;
    }, error => console.error(error));
  }

  public goNext(e) {
    this.validateLogin(null);

    if (!this.loginMeta.invalid && !this.passwordMeta.invalid && this.agree) {
      this.step2 = !this.step2;
    }
  }

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

  public pullProvince(e) {
    console.log(e);
    this.httpClient.get<Province[]>(this.baseUrl + 'api/SampleData/Provinces?countryId='+e.target.value).subscribe(result => {
      this.provinces = result;
    }, error => console.error(error));
  }
}
