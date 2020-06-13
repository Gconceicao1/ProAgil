// Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ToastrModule } from 'ngx-toastr';
// Services
import { EventoService } from './_services/Evento.service';
// Components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './navMenu/navMenu.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardsComponent } from './dashboards/dashboards.component';
import { ContatoComponent } from './contato/contato.component';
import {TituloComponent } from './_shared/titulo/titulo.component';
// Pipes
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';



@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      EventosComponent,
      PalestrantesComponent,
      DashboardsComponent,
      ContatoComponent,
      TituloComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      AlertModule.forRoot(),
      BsDatepickerModule.forRoot(),
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      ToastrModule.forRoot({ timeOut: 10000, positionClass: 'toast-bottom-right', preventDuplicates: true})
   ],

   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
