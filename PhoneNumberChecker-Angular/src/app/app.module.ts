import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { FormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { PhoneCheckComponent } from './phone-check/phone-check.component'
import { PhoneCheckFormComponent } from './phone-check/phone-check-form/phone-check-form.component'
import { HttpClientModule } from '@angular/common/http'
import { PhoneCheckService } from './services/phone-check.service'

@NgModule({
  declarations: [AppComponent, PhoneCheckComponent, PhoneCheckFormComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [PhoneCheckService],
  bootstrap: [AppComponent],
})
export class AppModule {}
