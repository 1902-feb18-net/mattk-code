import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pokemon } from './models/pokemon';
import { Observable } from 'rxjs';

// services are meant to be injected into whatever depends ont ehm (DI)
// we use @INjectable decoratro to define in what scope this service is reachable

@Injectable({
  providedIn: 'root'
})
export class PokemonApiService {
  baseUrl = 'https://pokeapi.co/api/v2/pokemon'

  constructor(private httpClient: HttpClient) { }

  // this class can be repository pattern for my components
  searchByName(searchText: string): Observable<Pokemon[]> {
    let url = `${this.baseUrl}/${searchText}`;
    console.log(`sending request to ${url}`);
    let request = this.httpClient.get<Pokemon[]>(url);

    // rxJS gives us a tyupe called Observabnle with
    // a lot of powerful functional / asychronous behaviour
    return request; 
  }
}
