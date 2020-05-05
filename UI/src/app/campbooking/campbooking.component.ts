import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Camp } from '../shared/camp.model';
import { CampService } from '../shared/camp.service';
import { WeekDay } from '@angular/common';

@Component({
  selector: 'app-campbooking',
  templateUrl: './campbooking.component.html',
  styleUrls: ['./campbooking.component.css']
})
export class CampbookingComponent implements OnInit {

  campBook: FormGroup;
  startDateControl : FormControl;
  endDateControl : FormControl;
  billingaddressControl: FormControl;
  stateControl: FormControl;
  countryControl : FormControl;
  zipControl: FormControl;
  phoneNumberControl: FormControl;
  camp: Camp;
  public noOfNormaldays:number = 0;
  public noOfWeekend:number = 0;
  
  constructor(public campService: CampService,
  private router: Router,
  private route: ActivatedRoute,
  private toastr : ToastrService) { }
  campid : string;
  bookurl: string  = null;
  

  ngOnInit(): void {

    let startdate: Date;
    let enddate: Date;
 
  
    this.campid = this.campService.campIdForBooking.toString();
  
      this.campService.getCampById(this.campid)
      .subscribe((camp: Camp) => {
        if(camp != null)
        {
        this.camp = camp;
        this.campService.campIdForBooking = 0;
        }
        else {
          this.router.navigate(['']);
        }
      });

      
     this.phoneNumberControl = new FormControl('', [Validators.required,Validators.min(1000000000),Validators.max(9999999999)]);
     this.stateControl = new FormControl('', [Validators.required]);
     this.zipControl = new FormControl('', [Validators.required]);
     this.countryControl = new FormControl('', [Validators.required]);
     this.billingaddressControl = new FormControl('', [Validators.required]);
  
  this.campBook = new FormGroup({
  
    phoneNumber: this.phoneNumberControl,
    state: this.stateControl,
    zip: this.zipControl,
    country : this.countryControl,
    billingaddress: this.billingaddressControl          
  });



  function isWeekend(dateString) {
    var day = dateString.getDay();
    return day === 0 || day === 6 || day === 5;
  }
  
  var checkinDate = new Date(this.campService.startdate)
  var checkoutDate =  new Date(this.campService.enddate)
  while(checkinDate < checkoutDate) 
  {
      if(isWeekend(checkinDate))
      {
        this.noOfWeekend = this.noOfWeekend  + 1;

      } 
      else{
        this.noOfNormaldays = this.noOfNormaldays + 1;
      }
        checkinDate = new Date(checkinDate.setDate(checkinDate.getDate()+1));
   }

  if(this.noOfWeekend != 0) this.toastr.warning('Price are hiked on weekends','Alert')


  
    
    
}

value = '';
  onEnter(value: string) { this.value = value; }


onFormSubmit() {

  const {   startDate , endDate , phoneNumber , state, zip, country , billingaddress } = this.campBook.value;
 
  
  const campId=this.campid
  const id = 1;
  const TotalPrice = 0;
  this.campService.saveCampBooking(id, billingaddress , state,campId,this.campService.startdate, this.campService.enddate, TotalPrice,country, zip , phoneNumber)
    
  .subscribe((res) => {
      this.toastr.success('Your Reference Id is' + res,'Booking Register done')
      alert("Please note your Reference ID is :   "+res);
      this.router.navigate(["/home"]);
  },error=>{
    this.toastr.error('Booking cannot inserted','Booking Register not done')
  });

}
getControlValidationClasses(control: FormControl) {
  return {
    'is-invalid': control.touched && control.invalid,
    'is-valid': control.touched && control.valid
  };


}

}
