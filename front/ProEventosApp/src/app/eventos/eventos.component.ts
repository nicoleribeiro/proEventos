import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  // medida em EM
  widthImg: number = 6;
  marginImg: number = 1;
  showImg: boolean = true;

  constructor(
    private http:HttpClient
  ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  showImage(){
    this.showImg = !this.showImg;
  }

  public getEventos():void{
    this.http.get('https://localhost:7135/api/evento/').subscribe(
      response => this.eventos = response,
      error => console.log(error));
  }
}
