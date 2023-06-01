import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  apiurl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getAllPeople(): Observable<any> {
    const Url = this.apiurl + 'Person/GetPeople';
    return this.http.get<any>(Url);
  }

  getPersonById(personid: any): Observable<any> {
    return this.http.get<any>(
      this.apiurl + 'Person/GetPersonById?id=' + personid
    );
  }

  createPerson(personData: any): Observable<any> {
    return this.http.post<any>(this.apiurl + 'Person/InserPerson', personData);
  }
  updatePerson(personid: any, personData: any): Observable<any> {
    return this.http.post<any>(
      this.apiurl + 'Person/UpdatePerson?id=' + personid,
      personData
    );
  }
}
