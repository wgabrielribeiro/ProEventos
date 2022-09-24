import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public larguraImagem: number = 150;
  public margemImg: number = 2;
  public exibirImg: boolean = true;
  private filtroListado: string = '';

  modalRef!: BsModalRef;

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private modalService: BsModalService,
    private eventoService: EventoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService

    ) { }

  public ngOnInit(): void {
    this.spinner.show(
      "Erro!", {
        type: "line-scale-party",
        size: "large",
        bdColor: "rgba(0, 0, 0, 1)",
        color: "white",
        template:
          "<img src='https://media.giphy.com/media/o8igknyuKs6aY/giphy.gif'/>",
      }
    );
    this.getEventos();
  }

  public alterarImagem(){
    this.exibirImg = !this.exibirImg;
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe({
      next: (_eventos : Evento[]) => {
        this.eventos = _eventos
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });

  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('O Evento foi deletado com sucesso.', 'Deletado!');
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }

}
