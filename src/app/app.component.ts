import { Component, OnInit } from '@angular/core';
import { MenuItem, Message, MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  host: { class: 'app-component-container' }
})
export class AppComponent implements OnInit {
  menuUser: MenuItem[];

  displaySideBar: boolean;
  menuSideBar: MenuItem[];

  inputSearch: string;

  constructor(private messageService: MessageService){ }

  ngOnInit(){
    this.displaySideBar = false;
    this.inputSearch = "";
    this.menuUser = [
      { label: 'Account', items: [
        { label: 'Update', icon: 'pi pi-refresh', command: () => { this.update(); } },
        { label: 'Delete', icon: 'pi pi-times', command: () => { this.delete(); } }
      ]},
      { label: 'Options', items: [
        { label: 'Angular Website', icon: 'pi pi-external-link', url: 'http://angular.io' },
        { label: 'Router', icon: 'pi pi-upload', routerLink: '/fileupload' },
        { label: 'Quit', icon:'pi pi-power-off', command: () => { this.logout(); } }
      ]},
    ];
    this.menuSideBar = [
      { label:'T. I.', icon:'pi pi-fw pi-desktop', items:[
        { label: 'Front-end', routerLink: '/roadmap/frontend', command: () => { this.setDisplaySideBar(); } },
        { label: 'Back-end', routerLink: '/roadmap/backend', command: () => { this.setDisplaySideBar(); } },
        { label: 'DevOps', routerLink: '/roadmap/devops', command: () => { this.setDisplaySideBar(); } }
      ]},
      { separator: true },
      { label:'Optimization', icon:'pi pi-fw pi-cog', routerLink: '/roadmap/optimization', command: () => { this.setDisplaySideBar(); } },
      { separator: true },
      { label:'Data Science', icon:'pi pi-fw pi-chart-bar', routerLink: '/roadmap/datascience', command: () => { this.setDisplaySideBar(); } }
    ];
  }

  setDisplaySideBar = () => { this.displaySideBar = this.displaySideBar ? false : true }

  update = () => { this.messageService.add({severity:'success', key: 'success', summary:'Success', detail:'Data Updated'}); this.clear('success'); }
  delete = () => { this.messageService.add({severity:'warn', key: 'warn', summary:'Delete', detail:'Data Deleted'}); this.clear('warn'); }
  logout = () => { this.messageService.add({severity:'error', key: 'error', summary:'Logout', detail:'User Logged Out'}); this.clear('error'); }
  clear = (key: string) => { setTimeout(() => { this.messageService.clear(key); }, 3000); }
}
