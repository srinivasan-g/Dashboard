import { Component } from '@angular/core';
import { AppInfoService } from '../../shared/services';
import { VisualRange } from 'devextreme/common/charts';

@Component({
  templateUrl: 'home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  years = [1996, 1997, 1998];
  selectedYear = 1996
  countriesInfo: any;
  visualRange: VisualRange = {};
  constructor(private readonly service: AppInfoService) {}

  ngOnInit() {
    this.service.get('Order/GetOrder', this.years[0]).subscribe({
      next: (res: any) => {
        this.formateData(res);
      },
    });
  }

  formateData(res: any) {
    this.countriesInfo = res.map((item: any) => {
      return {
        year: new Date(item.orderDate).toLocaleString('default', {
          month: 'long',
        }), 
        smp: item.freight,
        Date: new Date(item.orderDate),
        shipAddress: item.shipAddress,
        shipCity: item.shipCity,
        shipCountry: item.shipCountry,
        shipName: item.shipName
      };
    });
  }

  customizeTooltip(arg: any) {
    const findObj = arg.point.aggregationInfo.data.find((d: any) =>  d.smp === arg.value)
    return {
      text:
        `Freight: $${arg.value}<br/>` +
        `OrderDate: ${new Date(arg.argumentText).getDate()}/${new Date(arg.argumentText).getMonth()}/${new Date(arg.argumentText).getFullYear()}<br/>`+
        `shipName: ${findObj.shipName}<br/>`+
        `shipAddress: ${findObj.shipAddress}<br/>`+
        `shipCity: ${findObj.shipCity}<br/>`+
        `shipCountry: ${findObj.shipCountry}<br/>`
    };
  }
  handelYearChange(data: any){
    this.service.get('Order/GetOrder', data.value).subscribe({
      next: (res: any) => {
        this.formateData(res);
      },
    });
  }
}
