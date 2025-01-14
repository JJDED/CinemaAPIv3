import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
// this is our entry to API
export class UserService {

//URL
url: string = "https://localhost:4200/api/Users";
url2: string = "https://localhost:7206/api/ffff";


// version 1 - Hardcoded!
getall():User[]{ return [
  {userId:12, firstName:"Palle", lastName:"Lone",  email:"Lars@lars.dk",
   postalCodeId:1234},
  {userId:13, firstName:"Jaime", lastName:"englishTheBest",  email:"Lars@lars.dk", postalCodeId:5555}
] }

userList:User[] = [
  {userId:12, firstName:"Palle", lastName:"Lone",  email:"Lars@lars.dk",
   postalCodeId:1234},
  {userId:13, firstName:"Jaime", lastName:"englishTheBest",  email:"Lars@lars.dk", postalCodeId:5555}
];


 getall2():User[]{ return this.userList; }


getall3():Observable<User[]>{
  return this.http.get<User[]>(this.url);
}

delete(idToDelete:number):void{
  this.http.delete(this.url+"/"+idToDelete);
}

  constructor(private http:HttpClient) { }
}