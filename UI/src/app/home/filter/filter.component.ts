import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CampService } from 'src/app/shared/camp.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {
 
 todayDate;
  search: FormGroup;
  checkInDateControl : FormControl;
  checkOutDateControl : FormControl;
  dropdownControl : FormControl;

constructor(private router: Router,
   private service:CampService,
   private toastr : ToastrService ) { }

ngOnInit(): void {
  this.checkInDateControl = new FormControl('');
  this.checkOutDateControl = new FormControl('');
  this.dropdownControl = new FormControl('');
  var today = new Date()
  this.todayDate = new Date().toISOString().substring(0, 10);
  
   
  this.search = new FormGroup({
    checkInDate : this.checkInDateControl,
    checkOutDate : this.checkOutDateControl,
    dropdown      : this.dropdownControl
  })  
  const currentDate = new Date().toISOString().substring(0, 10);
  
  this.search.controls["checkInDate"].setValue(currentDate);
  today.setDate(today.getDate() + 1)
  const tomorrowDate = today.toISOString().substring(0, 10);
  this.search.controls["checkOutDate"].setValue(tomorrowDate);
  this.search.controls["dropdown"].setValue("Any");
}

onSearch()
{
  this.service.startdate = this.checkInDateControl.value
  this.service.enddate = this.checkOutDateControl.value
  if(this.checkOutDateControl.value > this.checkInDateControl.value)
  {
  if(this.dropdownControl.value != "Any") this.service.capacity = this.dropdownControl.value;
  this.toastr.success('Filtered Camps','Filtered Applied',{timeOut: 2000});
  this.service.getSearchedCamp()
  this.service.bookNowButtonControl = true;
  }
  else 
  {
    this.toastr.error("ChecKin Date Must Be Smaller than checkout","Date Filter Error");
  }
  // this.router.navigate(['/home'], { queryParams: { startdate: checkInDate , enddate : checkOutDate , capacity : dropdown } });
 
}

}
