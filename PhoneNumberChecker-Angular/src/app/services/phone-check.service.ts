import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Result } from './../models/result.model'
import { Country } from './../models/country.model'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class PhoneCheckService {
  constructor(private http: HttpClient) {}

  readonly baseURL = 'https://localhost:7057/api/number-check'

  public validationResult: Result = new Result()

  countryList: Country[] = []
  countryId: string
  phoneNumber: string

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  }

  getCountries(): Observable<any> {
    return this.http.get(this.baseURL)
  }

  // call get api to get validation result
  getPhoneNumber() {
    //console.log(countryId)
    return this.http.get(
      `${this.baseURL}/${this.countryId}/${this.phoneNumber}`,
    )
  }

  // update result table from input result
  updateResult(result: any) {
    // this.validationResult = result
    //this.validationResult = new Result{result}
    this.validationResult = new Result()
    this.validationResult = Object.assign(this.validationResult, result)
    console.log(this.validationResult)
  }

  getDowland() {
    return this.http.post(`${this.baseURL}/download/`, this.validationResult, {
      observe: 'response',
      responseType: 'blob',
    })
  }
}
