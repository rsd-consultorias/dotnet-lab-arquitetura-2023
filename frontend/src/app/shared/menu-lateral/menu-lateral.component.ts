import { NgForOf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuLateralItemComponent } from '../menu-lateral-item/menu-lateral-item.component';

@Component({
  standalone: true,
  selector: 'app-menu-lateral',
  imports: [NgbCollapseModule, NgForOf, MenuLateralItemComponent],
  templateUrl: './menu-lateral.component.html',
  styleUrls: ['./menu-lateral.component.scss']
})
export class MenuLateralComponent {
  @Input() menus?: Array<any>
}
