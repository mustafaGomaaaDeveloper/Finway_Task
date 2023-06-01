import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../Service/person.service';
import { person } from '../../model/personModel';

@Component({
  selector: 'app-inserupdate-person',
  templateUrl: './inserupdate-person.component.html',
  styleUrls: ['./inserupdate-person.component.scss'],
})
export class InserupdatePersonComponent implements OnInit {
  editMode: boolean = false;
  personId: any;
  personForm!: FormGroup;
  persondata!: person;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private personservices: PersonService
  ) {}

  ngOnInit(): void {
    this.createForm();
    this.personId = this.activatedRoute.snapshot.params['id'];
    if (this.personId) {
      this.editMode = true;
      this.getPerson(this.personId);
    }
  }

  createForm() {
    this.personForm = this.fb.group({
      name: [
        this.persondata?.name ? this.persondata.name : '',
        Validators.required,
      ],
      email: [
        this.persondata?.email ? this.persondata.email : '',
        Validators.required,
      ],
      dateOfBirth: [
        this.persondata?.dateOfBirth ? this.persondata.dateOfBirth : '',
        Validators.required,
      ],
      country: [
        this.persondata?.country ? this.persondata.country : '',
        Validators.required,
      ],
    });
  }

  get Name(): any {
    return this.personForm.get('name');
  }
  get email(): any {
    return this.personForm.get('email');
  }
  get dateOfBirth(): any {
    return this.personForm.get('dateOfBirth');
  }
  get country(): any {
    return this.personForm.get('country');
  }

  getPerson(personid: any) {
    this.personservices.getPersonById(personid).subscribe((res: any) => {
      this.persondata = res.responseObject;
      console.log(res);
      this.createForm();
    });
  }

  submitFormperson() {
    console.log(this.personId, this.personForm.value);

    if (this.editMode) {
      this.personservices
        .updatePerson(this.personId, this.personForm.value)
        .subscribe((res) => {
          console.log(res);
          res.status == 1
            ? this.router.navigate(['/'])
            : console.log('Error In Update');
        });
    } else {
      this.personservices
        .createPerson(this.personForm.value)
        .subscribe((res) => {
          console.log(res);
          res.status == 1
            ? this.router.navigate(['/'])
            : console.log('Error In Insert');
        });
    }
  }
}
