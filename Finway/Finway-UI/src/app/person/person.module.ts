import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonRoutingModule } from './person-routing.module';
import { ListpersonComponent } from './Component/listperson/listperson.component';
import { PersonCardComponent } from './Component/person-card/person-card.component';
import { InserupdatePersonComponent } from './Component/inserupdate-person/inserupdate-person.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DateToAgePipe } from '../Helper/pips/date-to-age.pipe';
import { NgxPrintModule } from 'ngx-print';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    ListpersonComponent,
    PersonCardComponent,
    InserupdatePersonComponent,
    DateToAgePipe,
  ],
  imports: [
    CommonModule,
    PersonRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgxPrintModule,
  ],
})
export class PersonModule {}
