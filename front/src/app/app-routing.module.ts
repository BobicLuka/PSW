import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMedicamentsComponent } from './add-medicaments/add-medicaments.component';
import { AddTerminComponent } from './add-termin/add-termin.component';
import { AppComponent } from './app.component';
import { CreateFeedbackComponent } from './create-feedback/create-feedback.component';
import { FeedbackListComponent } from './feedback-list/feedback-list.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MedicamentsListComponent } from './medicaments-list/medicaments-list.component';
import { RegisterComponent } from './register/register.component';
import { TerminsComponent } from './termins/termins.component';
import { UsersListComponent } from './users-list/users-list.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'feedback-list', component: FeedbackListComponent },
  { path: 'user-list', component: UsersListComponent },
  { path: 'feedback-list', component: FeedbackListComponent },
  { path: 'create-feedback', component: CreateFeedbackComponent },
  { path: 'medicaments-list', component: MedicamentsListComponent },
  { path: 'add-medicaments', component: AddMedicamentsComponent },
  { path: 'add-termin', component: AddTerminComponent },
  { path: 'termins', component: TerminsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
