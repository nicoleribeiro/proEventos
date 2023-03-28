import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  // medida em EM
  widthImg: number = 6;
  marginImg: number = 1;
  showImg: boolean = true;
  // Two-way data binding
  private _filtroLista: string = '';

  public getEventos():void{
    this.http.get('https://localhost:7135/api/evento/').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error));
  }

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any{
    // converter para maiúsculo
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  showImage(){
    this.showImg = !this.showImg;
  }
}
