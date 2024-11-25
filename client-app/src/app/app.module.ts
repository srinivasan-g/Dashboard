import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { DxHttpModule } from 'devextreme-angular/http';
import { AppRoutingModule } from './app-routing.module';
import { SideNavOuterToolbarModule, SingleCardModule } from './layouts';
import { ScreenService } from './shared/services/screen.service';
import { AppInfoService } from './shared/services';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    DxHttpModule,
    SideNavOuterToolbarModule,
    SingleCardModule,
    AppRoutingModule
  ],
  providers: [
    ScreenService,
    AppInfoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
