import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../Model/Contact'

const baseUrl = 'https://localhost:44327';

const httpOptions = {
  headers: new HttpHeaders({
    'ApiKey':'pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${baseUrl}/GetAllContacts`, httpOptions);
  }

  addNewContact(data: any): Observable<any> {   
    return this.http.post(`${baseUrl}/AddNewContact`, data,httpOptions);
  }
  
  sendNewMessage(data:any):Observable<any>{   
    return this.http.post(`${baseUrl}/SendMessage`, data,httpOptions);
  }
}
