import { Component } from '@angular/core';
import { PropertiesApiService } from './properties-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  data : Property[] = [];
  columns: (keyof Property)[] = ['address', 'yearBuilt', 'listPrice', 'monthlyRent', 'grossYield'];

  constructor(private _propertiesApi: PropertiesApiService) { }

  ngOnInit() {
    this._propertiesApi.get()
      .subscribe(data => this.data = data);
  }
}