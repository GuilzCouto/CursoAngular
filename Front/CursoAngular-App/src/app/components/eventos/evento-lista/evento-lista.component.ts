import { Router } from '@angular/router';
import { EventoService } from './../../../services/evento.service';
import { Evento } from './../../../models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public filteredEventos: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public showImg: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList (value : string) {
    this._filterList = value;
    this.filteredEventos = this.filterList ? this.filterEvents(this.filterList) : this.eventos;
  }

  public filterEvents(filterFor: string): Evento[] {
      filterFor = filterFor.toLocaleLowerCase();
      return this.eventos.filter(
        (evento: {temaEvento: string;}) => evento.temaEvento.toLocaleLowerCase().indexOf(filterFor) !== -1
      )
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router,
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public changeImg(): void{
    this.showImg = !this.showImg;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next:(_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.filteredEventos = this.eventos;
      },
      error: (error:any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos', 'Erro!');
      },
      complete: () => this.spinner.hide(),
    });

  }
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id: number): void{
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
