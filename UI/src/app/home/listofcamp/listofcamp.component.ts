import { Component, OnInit } from '@angular/core';
import { CampService } from 'src/app/shared/camp.service';
import { Camp } from 'src/app/shared/camp.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-listofcamp',
  templateUrl: './listofcamp.component.html',
  styleUrls: ['./listofcamp.component.css']
})
export class ListofcampComponent implements OnInit {

  constructor(public service : CampService,public router : Router,public route : ActivatedRoute) { }

  totalrecords : number
  page : number = 1 
  list : Camp[]
  searchObj;
  ngOnInit(): void {
     
    this.service.getList()
    if(this.service.list != undefined)
    this.totalrecords = this.service.list.length
    


    // if(this.service.startdate != null && this.service.enddate != null)
    //   {
    //     this.service.getSearchedCamp().subscribe((list : Camp[]) => {this.list = list as Camp[]
    //           this.totalrecords = list.length
    //           });
    //   }
  
  }

  arrayOne(n: number): any[] {
    return Array(n);
  }


  campbook(camp: Camp) {
    this.service.campIdForBooking = camp.Id;
    this.router.navigate(['/bookCamp']);
    this.service.bookNowButtonControl = false;
  }
}


