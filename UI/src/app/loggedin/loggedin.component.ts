import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-loggedin',
  templateUrl: './loggedin.component.html',
  styleUrls: ['./loggedin.component.css']
})
export class LoggedinComponent implements OnInit {

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: AuthService,
    private toastr : ToastrService) { }

    unavindicator : boolean = true;
    cnavindicator : boolean = false;
  ngOnInit(): void {
  }
  logout(){
    this.service.logout().subscribe(() =>{ 
    this.toastr.warning('admin logged out successfully','Logged Out')  
    this.router.navigateByUrl('/home')});    
}


onadd(){
  this.cnavindicator = false;
  this.unavindicator = true;
}

onupdate(){
  this.cnavindicator = true;
  this.unavindicator = false;
}
}
