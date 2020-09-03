import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-road-map',
  templateUrl: './road-map.component.html',
  host: { class: 'road-map-component-container' }
})
export class RoadMapComponent implements OnInit {
  id: string;
  paramsSubscription: Subscription

  constructor(private router: Router, private route: ActivatedRoute) {
    this.paramsSubscription = this.route.params.subscribe(params => {
      if(params['id'] === 'frontend' || params['id'] === 'backend' || params['id'] === 'devops' || params['id'] === 'optimization' || params['id'] === 'datascience')
        this.id = params['id'];
      else
        this.router.navigate(['/404'])
    })
  }

  ngOnInit() { }
}
