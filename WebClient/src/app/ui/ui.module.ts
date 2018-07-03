import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from '../app-routing.module';
import { NavigationComponent } from './navigation/navigation.component';

@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  declarations: [LayoutComponent, HeaderComponent, FooterComponent, NavigationComponent],
  exports: [LayoutComponent]
})
export class UiModule { }
