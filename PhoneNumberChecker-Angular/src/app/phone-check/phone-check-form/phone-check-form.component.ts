import { Component, OnInit } from '@angular/core'
import { NgForm } from '@angular/forms'
import { PhoneCheckService } from 'src/app/services/phone-check.service'

@Component({
  selector: 'app-phone-check-form',
  templateUrl: './phone-check-form.component.html',
  styleUrls: ['./phone-check-form.component.css'],
})
export class PhoneCheckFormComponent implements OnInit {
  constructor(public service: PhoneCheckService) {}

  ngOnInit(): void {
    // Get Country list when load page
    this.service.getCountries().subscribe((res) => {
      this.service.countryList = res
    })
  }

  // submit form -> update result model -> clear form
  onSubmit(form: NgForm): void {
    this.service.getPhoneNumber().subscribe({
      next: (res) => {
        this.service.updateResult(res)
        this.resetForm(form)
      },
      complete: () => console.info('complete'),
    })
  }

  // reset form
  resetForm(form: NgForm) {
    form.form.reset()
    this.service.phoneNumber = ''
  }
}
