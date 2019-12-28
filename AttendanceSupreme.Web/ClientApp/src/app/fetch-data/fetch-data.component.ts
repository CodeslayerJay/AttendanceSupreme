import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  
  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
      http.get(apiUrl + 'test').subscribe(result => {
          
    }, error => console.error(error));
  }
}
