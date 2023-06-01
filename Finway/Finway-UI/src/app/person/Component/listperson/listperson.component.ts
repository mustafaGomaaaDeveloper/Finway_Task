import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../Service/person.service';
import { person } from '../../model/personModel';

@Component({
  selector: 'app-listperson',
  templateUrl: './listperson.component.html',
  styleUrls: ['./listperson.component.scss'],
})
export class ListpersonComponent implements OnInit {
  personData: person[] = [];

  constructor(private personservice: PersonService) {}

  ngOnInit(): void {
    this.getAllPeople();
  }

  getAllPeople() {
    this.personservice.getAllPeople().subscribe((res: any) => {
      this.personData = res.responseObject;
    });
  }
}
