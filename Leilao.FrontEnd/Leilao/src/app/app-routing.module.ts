import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { ListLeiloesComponent } from './pages/list-leiloes/list-leiloes.component';
import { UserLeiloesComponent } from './pages/user-leiloes/user-leiloes.component';
import { NewLeilaoComponent } from './pages/new-leilao/new-leilao.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '', component: HomeComponent, children: [
      { path: 'new-leilao', component: NewLeilaoComponent },
      { path: 'user-leiloes', component: UserLeiloesComponent },
      { path: 'list-leiloes', component: ListLeiloesComponent },
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
