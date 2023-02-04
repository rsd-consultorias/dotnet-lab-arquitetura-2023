import { Component, OnInit } from '@angular/core';
import { AlertService } from '../services/alert.service';
import { ServicoQualquerService } from '../services/servico-qualquer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    
  }

}
