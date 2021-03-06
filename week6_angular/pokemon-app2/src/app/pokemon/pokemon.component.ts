import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../models/pokemon';
import { PokemonApiService } from '../pokemon-api.service';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemon.component.html',
  styleUrls: ['./pokemon.component.css']
})
export class PokemonComponent implements OnInit {
  pokemon: Pokemon[] = [];

  searchText = 'bulbasaur';

  // put access modifier on constructor parameter, it will be copied into a proeprty for you
  constructor(private pokeApi: PokemonApiService) { }

  getPokemon() {
    console.log(`getting pokemon for ${this.searchText}`);

    // we are subscribing to the observable
    this.pokeApi.searchByName(this.searchText).subscribe(pokemon => {
      console.log('received resopnse');
      console.log(pokemon);
      this.pokemon = pokemon;
    });
  }

  ngOnInit() {
  }

}
