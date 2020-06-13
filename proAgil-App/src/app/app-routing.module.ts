import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventosComponent } from './eventos/eventos.component';
import { DashboardsComponent } from './dashboards/dashboards.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { ContatoComponent } from './contato/contato.component';


const routes: Routes = [
 {path : 'eventos', component: EventosComponent}
 , {path : 'dashboards', component: DashboardsComponent}
 , {path : 'palestrantes', component: PalestrantesComponent}
 , {path : 'contatos', component: ContatoComponent}
 , {path : '', redirectTo: 'dashboards', pathMatch: 'full'}
 , {path : '**', redirectTo: 'dashboards', pathMatch: 'full'}
 


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
