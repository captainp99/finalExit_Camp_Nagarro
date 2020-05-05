import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Camp } from '../shared/camp.model';
import { CampService } from '../shared/camp.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Bookingcamp } from '../shared/bookingcamp.model';
import { StarRatingComponent } from 'ng-starrating';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-managebooking',
  templateUrl: './managebooking.component.html',
  styleUrls: ['./managebooking.component.css']
})
export class ManagebookingComponent implements OnInit {
  booking: FormGroup;
  refnoControl : FormControl;
  bookingDetails:Bookingcamp;
  camp:Camp;
  
  id;
  referno ;
  startdate;
  enddate
  datatoshow = true;
  sDate
  eDate

  constructor(
    public service : CampService,
    private route:ActivatedRoute,
    private router: Router,
    private toastr : ToastrService   
  ) { }

  ngOnInit(): void {
    this.refnoControl = new FormControl('');
     
    this.datatoshow = true;

    this.booking = new FormGroup({
      refno : this.refnoControl,
    })

   
  }
  

  getbooking()
  {
    const { refno } = this.booking.value;
    this.referno=refno;
    
    this.service.getBookingDetails(this.referno).subscribe((details:Bookingcamp) => {
      if(details!=null){
        
      this.bookingDetails=details;
      this.sDate = details.StartDate;
      this.sDate = this.sDate.substring(0,10)
      this.eDate = details.EndDate;
      this.eDate = this.eDate.substring(0,10)
      this.id=details.CampId;
      var myDate = new Date(Date.now());
     
      this.startdate=details.StartDate;
      this.enddate = details.EndDate;
      if(this.enddate.substring(0, 10) < myDate.toISOString().substring(0, 10))
      {
        this.datatoshow = false;
        
      }
      
      this.service.getCampById(this.id)
      .subscribe((camp: Camp) => {
        this.camp = camp;
      });
     }else{
       alert('Booking Not Exist')
       
       window.location.reload();
      
    }});
  }


  deleteBooking(){
    
   var myDate = new Date(Date.now());
  if(this.startdate.substring(0, 10) > myDate.toISOString().substring(0, 10)){
  
   var ans=confirm("Are you sure ?");
    if(ans==true){
    this.service.deleteCampBooking( this.referno) .subscribe((res) => {
        this.toastr.success("Booking deleted successfully","Booking Deleted Suucessfully");
          window.location.reload();
        
      });
    }
  }
  else{
    this.toastr.warning("you cannot delete the past booking","Warning");
    window.location.reload(); 
  }
  }
  rating
  referenceNumber
  ratingComponentClick(clickObj: any): void {
     
    this.rating = clickObj.rating;
 }

 OnSubmitRating(campid)
 { 
   this.service.SubmitRating(campid,this.rating,this.referno).subscribe(()=>
   this.toastr.success('Thank You For your Valuable Feedback','Now Your Booking is deleted') );
   window.location.reload();
 }


 
}
