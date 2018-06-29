import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { AppRoutingModule } from './/app-routing.module';
import { HomeModule } from './home/home.module';
import { ComponentsModule } from './components/components.module';
import { FriendsModule } from './friends/friends.module';
import { GamesModule } from './games/games.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    UiModule,
    AppRoutingModule,
    ComponentsModule,
    HomeModule,
    FriendsModule,
    GamesModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
