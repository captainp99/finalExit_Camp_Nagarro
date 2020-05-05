import { Injectable, EventEmitter } from '@angular/core';
import { Camp } from './camp.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {config }  from '../config'

import { Bookingcamp } from './bookingcamp.model';
import { Rating } from './rating.model';


@Injectable({
  providedIn: 'root'
})
export class CampService {
  formData : Camp;
  ratingObject : Rating = new Rating();
  list : Camp[];
  startdate = null
  bookNowButtonControl : boolean = false;
  enddate = null
  campIdForBooking = 0;
  capacity = 1
  readonly rootURL = config.campUrl;
  readonly rootURL2= config.bookingUrl;
 
  constructor(private http : HttpClient) { }
 
  createCamp(formData : Camp,FileToUpload : File)
  {
    

    const finaldata : FormData = new FormData()

    finaldata.append('Name',formData.Name)
    finaldata.append('Description',formData.Description)
    finaldata.append('Capacity',formData.Capacity.toString())
    finaldata.append('Price',formData.Price.toString())
    finaldata.append('Image',FileToUpload,FileToUpload.name)

    const headers = this.setheader();
    return this.http.post(this.rootURL + '/createcamp',finaldata,{headers, responseType: 'text' as 'json'})
  }
 
  getList()
  {
    
    this.http.get(this.rootURL + '/getallcamps').toPromise().then(res => this.list = res as Camp[]);
    
  }
  
  setheader(){
    let tokenStr = this.settoken();
      const headers = new HttpHeaders().set('Authorization', tokenStr);
      return headers;
  }

  settoken(){
    let tokenStr = "Bearer "+localStorage.getItem('JWT_TOKEN');
    return tokenStr;
  }

  deleteCamp(Id : number)
  {
    return this.http.delete(this.rootURL + '/deletecamp/' + Id)
  }

  updateCamp(formData : Camp,FileToUpload : File, id : number)
  {

    const finaldata : FormData = new FormData()

    finaldata.append('Name',formData.Name)
    finaldata.append('Description',formData.Description)
    finaldata.append('Capacity',formData.Capacity.toString())
    finaldata.append('Price',formData.Price.toString())
    if(FileToUpload != null) finaldata.append('Image',FileToUpload,FileToUpload.name)
    finaldata.append('ImageReference',null)

    const headers = this.setheader();
    return this.http.patch(this.rootURL + '/updatecamp/' + id ,finaldata,{headers, responseType: 'text' as 'json'})
  }

  getCampById(Id){
    return this.http.get(this.rootURL+'/getcamp/'+Id);
   }
 
   saveCampBooking(Id : number , BillingAddress: string, State: string ,CampId : string, StartDate : Date,
                   EndDate : Date, TotalAmount : number , Country : string, ZipCode : number , CellPhone : number   ) {
           
            const campToBook: Bookingcamp = {
       
                   Id,
  
                   CampId  : CampId,  
  
                   StartDate,  
  
                   EndDate,
         
                   TotalAmount, 
  
                   BillingAddress,
  
                   State,
  
                   Country,
  
                   ZipCode,
         
                   CellPhone,
     };
     return this.http.post(this.rootURL2 +'/addbooking/'+CampId, campToBook);  
   }
 
   getSearchedCamp()
   { 
     this.http.get(this.rootURL2+'/filtercamp/?capacity='+this.capacity+'&startdate='+this.startdate+'&enddate='+this.enddate).toPromise().then(res => this.list = res as Camp[]);
   }

   getBookingDetails(refno){
    return this.http.get(this.rootURL2+'/?referenceid='+refno);
  }
  deleteCampBooking(refno){
    return this.http.delete(this.rootURL2+'/?referenceid='+refno);
  }

  SubmitRating(campId,rating,referId)
  {
    
    this.ratingObject.CampId = campId
    this.ratingObject.Rating = rating
    this.ratingObject.ReferenceId = referId
    return this.http.post(this.rootURL2 +'/camprating', this.ratingObject);



  }
}
