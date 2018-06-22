import { Component, Input, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { timer, Subscription } from 'rxjs';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss'],
  animations: [
    trigger('alertState', [
      state('visible', style({
        opacity: 1,
        transform: 'scale(1)'
      })),
      state('invisible', style({
        opacity: 0.5,
        transform: 'scale(0.5)'
      })),
      transition('* => *', animate('500ms ease-in'))
    ])
  ]
})
export class AlertComponent implements OnInit {

  public allowClose: boolean;
  public title: string;
  public body: string;
  public timerHandle: number;
  private _subscription: Subscription;
  public visibilityState = 'invisible';

  constructor() {
   }

  ngOnInit() {
  }

  public show(title: string, text: string, allowClose: boolean = true, duration: number = 5000) {
    console.log(`Showing alert for ${duration} milliseconds`);
    const self = this;
    self.unsubscribe();
    self.title = title;
    self.body = text;
    self.allowClose = allowClose;
    const tmr = timer(duration);
    this._subscription = tmr.subscribe(() => {
      self.toggleState();
      self.unsubscribe();
     });
    self.toggleState();
  }
  toggleState() {
    this.visibilityState = this.visibilityState === 'visible' ? 'invisible' : 'visible';
    console.log(`Changed alert state to ${this.visibilityState}`);
  }

  unsubscribe() {
    if (typeof this._subscription !== 'undefined' && this._subscription !== null) {
      this._subscription.unsubscribe();
    }
  }

}
