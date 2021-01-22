import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FeedbackListComponent } from './feedback-list/feedback-list.component';
import { CreateFeedbackComponent } from './create-feedback/create-feedback.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserService } from './services/userService';
import { UsersListComponent } from './users-list/users-list.component';
import { MatTableModule } from '@angular/material/table';
import { MedicamentsListComponent } from './medicaments-list/medicaments-list.component';
import { AddMedicamentsComponent } from './add-medicaments/add-medicaments.component';
import { HomeComponent } from './home/home.component';
import { AddTerminComponent } from './add-termin/add-termin.component';
import { TerminsComponent } from './termins/termins.component'  
import { CustomInterceptor } from './services/customInterceptor';
import { NgxMatDatetimePickerModule, NgxMatTimepickerModule,
  NgxMatNativeDateModule } from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { TerminService } from './services/terminService';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    FeedbackListComponent,
    CreateFeedbackComponent,
    UsersListComponent,
    MedicamentsListComponent,
    AddMedicamentsComponent,
    HomeComponent,
    AddTerminComponent,
    TerminsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatTableModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,MatDatepickerModule, NgxMatNativeDateModule,
  ],
  providers: [
    UserService,
    TerminService,
    { provide: HTTP_INTERCEPTORS, useClass: CustomInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
