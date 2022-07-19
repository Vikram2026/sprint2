import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { flight } from '../models/flight';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent  {

  flightservice: any;

  constructor(public httpc:HttpClient) {
  }

  flightModel: flight = new flight();
  flightModels: Array<flight> = new Array<flight>();
  Addflight() {
    console.log(this.flightModel);
   

    var flightto={
      flightNo:Number(this.flightModel.flightNo),  
      
      airline:this.flightModel.airline,
      
      fromPlace:this.flightModel.fromPlace,
     
      toPlace:this.flightModel.toPlace,

      days:this.flightModel.days,

      instrument:this.flightModel.instrument,

      businessSeats:this.flightModel.businessSeats,
      
      nonBusinessSeats:this.flightModel.nonBusinessSeats,
      
      ticketCost:Number(this.flightModel.ticketCost),
      
      rows:Number(this.flightModel.rows),
      
      meal:this.flightModel.meal,
      startDateTime:this.flightModel.startDateTime,
      endDateTime:this.flightModel.endDateTime


    }
    this.httpc.post("https://flightapiazure.azurewebsites.net/api/Flight",flightto).subscribe((res: any)=>this.PostSuccess(res),(res: any)=>this.PostError(res));
    this.flightModel = new flight();
    
  }
  PostSuccess(res:any){
    console.log(res);
    
  }
  PostError(res:any){
    console.log(res);
  }
  Editflight(input: flight) {
    this.flightModel = input;
  }
  Deleteflight(input: flight) {
    var index=this.flightModels.indexOf(input);
    this.flightModels.splice(index,1);
  }
  getData(){
    console.log("Hi");
    this.httpc.get("https://flightapiazure.azurewebsites.net/api/Flight").subscribe((res: any)=>this.GetSuccess(res),(res: any)=>this.GetError(res));
  }
  
  GetSuccess(input:any){
    this.flightModels=input;
  }
  GetError(input:any){
    console.log(input);
  }
  uploadFile=(files:any)=>{
    console.log("Hi");
    
    if(files.length==0){
      return;
    }
    let filetoUpload=<File>files[0];
    const formData=new FormData();
    formData.append('file',filetoUpload,filetoUpload.name)
    this.httpc.post("https://localhost:44311/api/upload",formData).subscribe((res: any)=>console.log(res),(res: any)=>console.log(res));
  }
  
  
}