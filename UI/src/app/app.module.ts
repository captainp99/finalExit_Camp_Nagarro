import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FilterComponent } from './home/filter/filter.component';
import { ListofcampComponent } from './home/listofcamp/listofcamp.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoggedinComponent } from './loggedin/loggedin.component';
import { AddcampComponent } from './loggedin/addcamp/addcamp.component';
import { UpdatecampComponent } from './loggedin/updatecamp/updatecamp.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { ToastrModule } from 'ngx-toastr';
import { RatingModule } from 'ng-starrating';
import { LoginComponent } from './auth/login/login.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { ManagebookingComponent } from './managebooking/managebooking.component';
import { CampbookingComponent } from './campbooking/campbooking.component';
import { RatingComponent } from './rating/rating.component'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FilterComponent,
    ListofcampComponent,
    LoggedinComponent,
    AddcampComponent,
    UpdatecampComponent,
    LoginComponent,
    ManagebookingComponent,
    CampbookingComponent,
    RatingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatButtonModule,
     MatFormFieldModule, 
     MatInputModule,
     ReactiveFormsModule,
     NgxPaginationModule,
     RatingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule{} 
