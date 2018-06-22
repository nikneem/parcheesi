import { Component, OnInit } from '@angular/core';
import { AlertComponent } from '../components/alert/alert.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private alert: AlertComponent) { }

  ngOnInit() {
    setTimeout(() =>  {    this.alert.show('Hellow', 'Haaiiiii'); }, 2500);
  }

}
