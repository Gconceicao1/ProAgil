import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  eventosFiltrados: Evento[];
  modalRef: BsModalRef;
  _filtroLista = '';





  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService
    ) {}
  get filtroLista(): string {
      return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  openModal(templete: TemplateRef<any> ) {
    this.modalRef = this.modalService.show(templete);
  }



  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );

  }
  alterImage() {
    this.mostrarImagem = !this.mostrarImagem;

  }
  getEventos() {
    this.eventoService.getAllEventos().subscribe(
      ( _eventos: Evento[]) => {
        this.eventos = _eventos;
        console.log(_eventos);
      },
      error => {
        console.log(error);
      }
    );
  }


}
