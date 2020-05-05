import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RandomGuard } from './auth/guard/random.guard';
import { AddcampComponent } from './loggedin/addcamp/addcamp.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth/guard/auth.guard';
import { LoggedinComponent } from './loggedin/loggedin.component';
import { CampbookingComponent } from './campbooking/campbooking.component';
import { ManagebookingComponent } from './managebooking/managebooking.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'createcamp', component: AddcampComponent,  canActivate: [RandomGuard], canLoad: [RandomGuard] },
  { path: 'loggedin', component: LoggedinComponent,  canActivate: [RandomGuard], canLoad: [RandomGuard] },
  { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
  { path: 'bookCamp',component: CampbookingComponent},
  {path:'managecamp',component: ManagebookingComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
