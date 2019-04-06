import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Character } from './models/character';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CharacterApiService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Character[]> {
    let baseUrl = environment.charApiUrl;
    console.log(`Using API url ${baseUrl}`);
    let url = `${baseUrl}/api/character`;

    return this.http.get<Character[]>(url, { withCredentials: true });


  }

  login(login): Observable<{}> {
    let url = `${environment.charApiUrl}/url/login`;
    return this.http.post(url, login, { withCredentials: true }).pipe(res => {
      let url = `${environment.charApiUrl}/api/account/details`;
      return this.http.get<Account>(url, { withCredentials: true}).pipe(account => {
        sessionStorage['account'] = account;
        return account;
      });
    });

  }
}
