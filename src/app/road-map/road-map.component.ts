import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-road-map',
  templateUrl: './road-map.component.html',
  host: { class: 'road-map-component-container' }
})
export class RoadMapComponent implements OnInit {
  id: string;
  paramsSubscription: Subscription

  constructor(private route: ActivatedRoute) {
    this.paramsSubscription = this.route.params.subscribe(params => {
      this.id = params['id'];
    })
    
    console.log('caminho: ', this.id)
  }

  ngOnInit() { }
}
