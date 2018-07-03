import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GameslistComponent } from './games/gameslist/gameslist.component';
import { FriendslistComponent } from './friends/friendslist/friendslist.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'games', component: GameslistComponent },
  { path: 'friends', component: FriendslistComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];


@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [RouterModule]
})
export class AppRoutingModule {}

