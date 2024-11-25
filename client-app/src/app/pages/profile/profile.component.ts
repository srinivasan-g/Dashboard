import { Component } from '@angular/core';
import { ColCountByScreen } from '../../app-navigation';

@Component({
  templateUrl: 'profile.component.html',
  styleUrls: [ './profile.component.scss' ]
})

export class ProfileComponent {
  employee: any;
  colCountByScreen = ColCountByScreen;

  constructor() {
    this.employee = {
      Prefix: 'Mrs.',
      FirstName: 'Nancy',
      LastName: 'Davolio',
      Title: 'Sales Representative',
      BirthDate: new Date('1974/11/5'),
      HireDate: new Date('2005/05/11'),
      Address: '4600 N Virginia Rd.',
      City: 'London',
      Region: '',
      PostalCode: 'Ha4',
      Country: '',
      HomePhone: '',
      Extension: '',
      Photo: '',
      Notes: '',
      ReportsTo: '',
      PhotoPath: '',
    };
    
  }
}
