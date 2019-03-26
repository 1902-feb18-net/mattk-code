import { Card } from "./card";

export class MtgService {
    private url: string;

    getByName(name: string, onSuccess: (card: Card) => void): void {
        let fragment: string = '/cards/named'
        let url = `${this.url}${fragment}?fuzzy=${name}`
        fetch(this.url)
            .then(r => r.json())
            .then(onSuccess);
    }

    constructor(url: string) {
        this.url = url;
    }
}