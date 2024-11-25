import { Component, OnInit } from '@angular/core';
import 'devextreme/data/odata/store';
import { AppInfoService } from '../../shared/services';
import { combineLatest, forkJoin } from 'rxjs';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';

@Component({
  templateUrl: 'product.component.html',
})
export class ProductComponent implements OnInit {
  dataSource: any;
  categoryData: any;
  selectedItemKeys: string[] = [];

  isVisible = false;
  message = '';
  type: any = 'info';

  constructor(private readonly service: AppInfoService) {}

  ngOnInit() {
    const product = this.service.get('Products/GetProduct');
    const category = this.service.get('Category/GetCategory');

    forkJoin([product, category]).subscribe((res: any) => {
      this.formateData(res);
    });
  }

  formateData(res: any) {
    this.dataSource = {
      store: res[0],
      onSaved: (e: any) => {
        this.cellValueChanged(e);
      },
    };
    this.categoryData = res[1];
    this.getFilteredCategoryData = this.getFilteredCategoryData.bind(res[1]);
  }

  getFilteredCategoryData(options: { data: any }) {
    return {
      store: this.categoryData,
      filter: options.data
        ? ['CategoryId', '=', options.data.categoryId]
        : null,
    };
  }

  cellValueChanged(e: any) {
    if (e.changes.length) {
      const changeData = e.changes;
      combineLatest(
        changeData.map((item: any) =>
          this.service.patch(
            `Products/UpdateProduct/${item.data.productId}`,
            item.data
          )
        )
      ).subscribe({
        next: (value) => {
          this.isVisible = true;
          this.message = 'Product updates successfully ';
          this.type = 'success';
        },
        error: (err) => {
          this.isVisible = true;
          this.message = 'something wrong occurred: ' + err.message;
          this.type = 'error';
        },
      });
    }
  }
}
