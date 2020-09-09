import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-road-map',
  templateUrl: './road-map.component.html',
  host: { class: 'road-map-component-container' }
})
export class RoadMapComponent implements OnInit {
  id: string;
  paramsSubscription: Subscription;

  requestedData: any;

  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) {
    this.paramsSubscription = this.route.params.subscribe(params => {
      if(params['id'] === 'frontend' || params['id'] === 'backend' || params['id'] === 'devops' || params['id'] === 'optimization' || params['id'] === 'datascience')
        this.id = params['id'];
      else
        this.router.navigate(['/404'])
    })
  }

  ngOnInit() {
    this.getData().subscribe(data => {
      console.log(data);
      this.requestedData = data;
    });
  }

  public getData(): Observable<any> {
    return this.http.get("../assets/json/RoadMapV0.json");
  }
}
