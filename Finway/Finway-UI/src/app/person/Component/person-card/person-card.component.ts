import { Component, Input, OnInit } from '@angular/core';
import { person } from '../../model/personModel';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.scss'],
})
export class PersonCardComponent implements OnInit {
  @Input() personcardData!: person;
  constructor() {}

  ngOnInit(): void {}

  printPage() {
    window.print();
  }
}
