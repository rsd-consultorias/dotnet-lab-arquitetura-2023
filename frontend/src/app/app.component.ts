import { Component } from '@angular/core';
import { AlertService } from './services/alert.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'Lab Arquitetura 2023';
  menus?: Array<any> = [];

  constructor() {
    this.menus?.push({
      id: 0,
      display: 'Primeiro Menu',
      subMenus: [
        {
          id: 0,
          display: 'Home',
          target: '/home'
        },
        {
          id: 1,
          display: 'Dashboard',
          target: '/dashboard'
        }
      ]
    });
    for (let i = 1; i < 10; i++) {
      let item = {
        id: i,
        display: `Menu de Teste ${i}`,
        subMenus: [{}]
      };

      item.subMenus = [];

      for (let i = 0; i < 20; i++) {
        let subItem = {
          display: `Submenu ${i}`,
          target: `/dashboard`
        };
        item.subMenus.push(subItem);
      }

      this.menus!.push(item);
    }
  }
}
