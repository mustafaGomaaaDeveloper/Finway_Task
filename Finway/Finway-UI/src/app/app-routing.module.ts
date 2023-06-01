import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IsauthorizedGuard } from './auth/Guard/isauthorized.guard';
import { ModelIsloginGuard } from './auth/Guard/model-islogin.guard';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: '',
    canLoad: [ModelIsloginGuard],
    loadChildren: () =>
      import('./layout/layout.module').then((m) => m.LayoutModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
