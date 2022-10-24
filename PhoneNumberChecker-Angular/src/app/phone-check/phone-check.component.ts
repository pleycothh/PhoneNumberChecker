import { Component, OnInit } from '@angular/core'
import { PhoneCheckService } from '../services/phone-check.service'

@Component({
  selector: 'app-phone-check',
  templateUrl: './phone-check.component.html',
  styleUrls: ['./phone-check.component.css'],
})
// display result
export class PhoneCheckComponent implements OnInit {
  constructor(public service: PhoneCheckService) {}

  ngOnInit(): void {
    // do nothing
  }

  // dowland option
  onDownland(): void {
    this.service.getDowland().subscribe({
      next: (res) => {
        let fileName = 'Validation_Result.csv' // <-- Dowland File Name
        let blob: Blob = res.body as Blob
        let a = document.createElement('a')
        a.download = fileName
        a.href = window.URL.createObjectURL(blob)
        a.click()
      },
      complete: () => console.info('Dowland complete'),
    })
  }
}
