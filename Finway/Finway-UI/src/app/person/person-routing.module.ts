import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListpersonComponent } from './Component/listperson/listperson.component';
import { InserupdatePersonComponent } from './Component/inserupdate-person/inserupdate-person.component';

const routes: Routes = [
  { path: '', component: ListpersonComponent },
  { path: 'editperson/:id', component: InserupdatePersonComponent },
  { path: 'addperson', component: InserupdatePersonComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PersonRoutingModule {}
