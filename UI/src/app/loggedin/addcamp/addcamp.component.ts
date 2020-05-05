import { Component, OnInit } from '@angular/core';
import { CampService } from 'src/app/shared/camp.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-addcamp',
  templateUrl: './addcamp.component.html',
  styleUrls: ['./addcamp.component.css']
})
export class AddcampComponent implements OnInit {

  constructor(public service : CampService,
    private toastr : ToastrService) { }

    imageUrl : string = './../../../assets/img/default.png';

    fileToUpload: File = null;


    handleFileInput(file: FileList) {
      this.fileToUpload = file.item(0);
  
      //Show image preview
      var reader = new FileReader();
      reader.onload = (event:any) => {
        this.imageUrl = event.target.result;
      }
      reader.readAsDataURL(this.fileToUpload);
    }

  ngOnInit() {
    this.resetform();
  }

  resetform(form? : NgForm){
    if(form!=null)
        form.resetForm();
    this.service.formData = {
      Id : null,
      Name : '',
      Description : '',
      Capacity : null,
      Price : null,
      ImageURL : null,
      ImageArray:null,
      Rating:null
    }
  }

  onSubmit(form : NgForm,Image){
    
    this.insertRecord(form,this.fileToUpload)
    this.resetform(form)
    this.imageUrl = './../../../assets/img/default.png';

  }

  insertRecord(form : NgForm,Image){
     this.service.createCamp(form.value,Image).subscribe(res => {
       this.toastr.success('camp inserted','Camp Register')

     },(err) => this.toastr.error('Enter all Fields'));
  }
}
