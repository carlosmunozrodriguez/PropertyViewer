import { Component } from '@angular/core';
import { PropertiesApiService } from './properties-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  data: Property[] = [];
  columns: (keyof Property)[] = ['address', 'yearBuilt', 'listPrice', 'monthlyRent', 'grossYield', 'saved'];

  constructor(private _propertiesApi: PropertiesApiService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this._propertiesApi.getProperties()
      .subscribe(data => this.data = data);
  }

  saveProperty(id: number) {
    this._propertiesApi.saveProperty(id)
      .subscribe(
        _ => {
          this.loadData();
          this._snackBar.open('Property Saved', undefined, { duration: 2000 });
        },
        errorResponse => this._snackBar.open((errorResponse.error as SavePropertyResult).errorMessage!, undefined, { duration: 2000 })
      );
  }
}