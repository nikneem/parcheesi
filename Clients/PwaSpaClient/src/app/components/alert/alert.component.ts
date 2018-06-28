import { Component, Input, OnInit, OnChanges, Injectable } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';
import { timer, Subscription } from 'rxjs';

@Injectable()
@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss'],
  animations: [
    trigger('visibilityChanged', [
      state('shown' , style({ opacity: 1 })),
      state('hidden', style({ opacity: 0 })),
      transition('* => *', animate('.5s'))
    ])
  ]
})
export class AlertComponent {

  public allowClose: boolean;
  public body: string;
  public title: string;
  public timerHandle: number;
  private _subscription: Subscription;


  isVisible: boolean;
  @Input() visibility = 'shown';

  constructor() {
    this.isVisible = false;
   }


  public show(title: string, text: string, allowClose: boolean = true, duration: number = 5000) {
    console.log(`Showing alert for ${duration} milliseconds`);
    const self = this;
    self.unsubscribe();
    self.title = title;
    self.body = text;
    self.allowClose = allowClose;

    this.toggleState();

    const tmr = timer(duration);
    this._subscription = tmr.subscribe(() => {
      self.toggleState();
      self.unsubscribe();
     });
  }

  toggleState() {
    this.isVisible = !this.isVisible;

    this.visibility = this.isVisible ? 'shown' : 'hidden';
    console.log(`Changed alert state to ${this.isVisible}`);
  }

  unsubscribe() {
    if (typeof this._subscription !== 'undefined' && this._subscription !== null) {
      this._subscription.unsubscribe();
    }
  }

}
