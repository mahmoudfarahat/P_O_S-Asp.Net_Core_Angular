import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UnitsService {

  constructor(private http:HttpClient) { }



getUnits(filter:any, skip:number, take:number){
console.log(filter)
  let params = new HttpParams()
Object.entries(filter).forEach(([key,value]:any) =>{
console.log(value);

  if(value)
  {
    params = params.append(key,value )
    console.log(key,value);
  }

})
console.log(params);
params.append("skip",skip);
params.append("take",take);


  return this.http.get<any>(`${environment.url}/Unit/Index?skip=${skip}&take=${take}` , {params})
}


}
