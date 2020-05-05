import { Component, OnInit } from '@angular/core';
import { CampService } from 'src/app/shared/camp.service';
import { ToastrService } from 'ngx-toastr';
import { Camp } from 'src/app/shared/camp.model';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-updatecamp',
  templateUrl: './updatecamp.component.html',
  styleUrls: ['./updatecamp.component.css']
})
export class UpdatecampComponent implements OnInit {


  list : Camp[];
  totalrecords : number
  page : number = 1 
  globalid : number;
imageUrl : string = null;

 fileToUpload: File = null;
  constructor(public service : CampService,
    private toastr : ToastrService) {
     }


   



    handleFileInput(file: FileList) {
      this.fileToUpload = file.item(0);
  
      //Show image preview
      var reader = new FileReader();
      reader.onload = (event:any) => {
        this.imageUrl = event.target.result;
      }
      reader.readAsDataURL(this.fileToUpload);
    }




  ngOnInit(){
    // this.service.getList().subscribe((list : Camp[]) => this.list = list as Camp[]);
    // this.totalrecords = this.list.length
    this.service.getList()
    this.totalrecords = this.service.list.length;
  }

  deleteCamp(Id : number)
  {
    var result = confirm('Are You sure You want to delete the camp?');
    if(result == true)
    {
     
      this.service.deleteCamp(Id).subscribe(res => {
        this.service.getList()
        this.toastr.warning('camp deleted succesfully','Camp deleted')
 
      });
    } 

  }

  populateForm(selectedRecord,id : number) {
    this.service.formData = Object.assign({}, selectedRecord);
    this.service.formData.Id = id
    this.globalid = id
    
  }

  onSubmit(form : NgForm){
  
    // this.service.updateCamp(form.value,this.fileToUpload,this.globalid).subscribe(res => {
    //   this.toastr.success('camp updated succesfully','Camp Updated')
    //   this.service.getList().subscribe((list : Camp[]) => this.list = list as Camp[]);
      

      
    // });

    this.service.updateCamp(form.value,this.fileToUpload,this.globalid).subscribe(res => {
        this.toastr.success('camp updated succesfully','Camp Updated')
        this.service.getList()
        
  
        
      });
  }
 

}
