import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup,  Validators, FormBuilder } from '@angular/forms';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale, } from 'ngx-bootstrap/chronos';
import { TmplAstTemplate } from '@angular/compiler';


defineLocale('pt-br', ptBrLocale);


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventos: Evento[];
  evento: Evento;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  eventosFiltrados: Evento[];
  registerForm: FormGroup;
  saveMode = 'post';
  // tslint:disable-next-line: variable-name
  _filtroLista = '';
  modalTitle = '';
  bodyDeletarEvento = '';




  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
    }

    ngOnInit() {
      this.validation();
      this.getEventos();
    }
    // abre e fecha o modal
    openModal(templete: any ) {
      this.registerForm.reset();
      templete.show();
    }
    // Insert
    novoEvento(template: any){
      this.openModal(template);
      this.modalTitle = 'Criar Novo Evento';
      this.saveMode = 'post';
    }
    // Update
    alterarEvento(evento: Evento,  template: any) {
      this.openModal(template);
      this.modalTitle = 'Editar Evento';
      this.saveMode = 'put';
      this.evento = evento;
      this.registerForm.patchValue(evento);
    }
    // Delete

    excluirEvento(evento: Evento, template: any){
      this.openModal(template);
      this.evento = evento;
      this.modalTitle = 'Exluir evento';
      this.bodyDeletarEvento =   `tem certeza que deseja deletar o evento: codigo: ${evento.id} ${evento.tema} ` ;
    }
  // Exibir e esconder imagem
    alterImage() {
      this.mostrarImagem = !this.mostrarImagem;
    }
    // Retorno dos eventos no front
    getEventos() {
      this.eventoService.getAllEventos().subscribe(
        // tslint:disable-next-line: variable-name
        ( _eventos: Evento[]) => {
         this.eventosFiltrados = this.eventos = _eventos;
          // console.log(_eventos);
        },
        error => {
          console.log(error);
        }
      );
    }

 // Filtro de eventos
  get filtroLista(): string {
      return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista  ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }


  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.id.toLocaleString().indexOf(filtrarPor) !== -1
      || evento.dataEvento.toLocaleString().indexOf(filtrarPor) !== -1
      || evento.qtdePessoas.toLocaleString().indexOf(filtrarPor) !== -1
      );

  }
// forumlário (reactive forms)

validation() {
this.registerForm = this.fb.group({
  tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
  local: ['',Validators.required],
  dataEvento: ['', Validators.required],
  qtdePessoas: ['', [Validators.required, Validators.max(120000)]],
  imageUrl: ['', Validators.required],
  telefone: ['', Validators.required],
  email: ['', [Validators.required, Validators.email]]

});
}

salvarAlteracao(template: any) {
 if (this.registerForm.valid) {   
   if (this.saveMode === 'post'){
    this.evento = Object.assign({}, this.registerForm.value);
    this.eventoService.postEvento(this.evento).subscribe((novoEvento: Evento) => {
      console.log(novoEvento);
      template.hide();
      this.getEventos();
    }, error => {
      console.log(error);
    });
   } else {
    this.evento = Object.assign({id: this.evento.id}, this.registerForm.value);
    this.eventoService.putEvento(this.evento).subscribe(
      () => {
      template.hide();
      this.getEventos();
    }, error => {
      console.log(error);
    });
   }
 }
}

confirmeDelete(template : any){
 this.eventoService.deleteEvento(this.evento.id).subscribe(
   () => {
    template.hide();
    this.getEventos();
   }, error =>{
    console.log(error);
   }  
 );
}

}
