import { Component } from '@angular/core';

@Component({
  selector: 'app-crud',
  imports: [],
  templateUrl: './crud.component.html',
  styleUrl: './crud.component.css'
})
export class CrudComponent {
  moviename:string[] = ["Palle", "Lone", "Lars"];

  create(data:string):void{this.moviename.push(data);}
  delete():void{ this.moviename.pop(); console.log("deleting");
  }

  getall():void{ console.log(this.moviename);}

  update(data:string,newdata:string):void{
    let temp = this.moviename.filter(x=>x.toLowerCase().indexOf(data.toLowerCase())>-1);
    console.log(temp);
    this.moviename[this.moviename.indexOf(temp[0])]=newdata;
    console.log("<br>"+this.moviename);
  }

  testingPrombt():void{
    let data = prompt("Skriv noget");
    console.log(data);
  }
  ngOnInit(){
    this.create("Ib");
    this.update("Lone","Lone the Great");
    this.delete();
    this.getall();
   // this.testingPrombt();
  }

}
