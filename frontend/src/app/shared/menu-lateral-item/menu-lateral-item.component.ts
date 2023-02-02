import { NgForOf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-menu-lateral-item',
  templateUrl: './menu-lateral-item.component.html',
  imports: [NgbCollapseModule, NgForOf, RouterModule],
  styleUrls: ['./menu-lateral-item.component.sass'],
  standalone: true
})
export class MenuLateralItemComponent {
  public isCollapsed = true;
  @Input() display?: string;
  @Input() menus?: Array<any>;
}
