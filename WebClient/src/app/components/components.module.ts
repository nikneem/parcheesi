import { NgModule } from '@angular/core';
import { AlertComponent } from './alert/alert.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule
  ],
  declarations: [ AlertComponent ],
  exports: [ AlertComponent ],
  providers: [ AlertComponent ]
})
export class ComponentsModule { }
