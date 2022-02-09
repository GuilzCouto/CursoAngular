import { Component, OnInit } from '@angular/core';
import { EventoService } from '@app/services/evento.service';
import { Evento } from '../../models/Evento';
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [EventoService]
})

export class EventosComponent implements OnInit {
 ngOnInit(): void {

 }
}
