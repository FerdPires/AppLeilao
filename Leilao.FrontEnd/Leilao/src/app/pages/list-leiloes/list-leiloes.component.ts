import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { AngularFireAuth } from '@angular/fire/auth';
import { GridOptions } from 'ag-grid-community';
import { I18nPtBrService } from 'src/app/i18nPtBr.service';

@Component({
  selector: 'app-list-leiloes',
  templateUrl: './list-leiloes.component.html',
  styleUrls: ['./list-leiloes.component.css']
})
export class ListLeiloesComponent implements OnInit {
  columns = ["Nome do Leilão", "Valor Inicial", "Tipo do item", "Status do Leilão", "Usuário responsável"];
  index = ["nome_leilao", "valor_inicial", "item_usado", "status_leilao", "nome_usuario"];

  public itemLeilao = [{
    "nome_leilao": "",
    "valor_inicial": "",
    "item_usado": "",
    "status_leilao": "",
    "nome_usuario": "",
  }];
  //rows: [];

  constructor(
    private service: DataService,
    private afAuth: AngularFireAuth,
    private _serviceTraduzGrid: I18nPtBrService,
  ) {

  }

  ngOnInit(): void {
    this.itemLeilao = [];
    this.afAuth.idToken.subscribe(token => {
      this.service.getAll(token)
        .subscribe(
          (data: any) => {
            data.forEach(element => {
              this.itemLeilao.push({
                "nome_leilao": element.nome_leilao,
                "valor_inicial": element.valor_inicial.toString().replace(".", ","),
                "item_usado": element.item_usado ? "Novo" : "Usado",
                "status_leilao": new Date(element.data_fim).getTime() < new Date().getTime() ? "Desativo" : "Ativo",
                "nome_usuario": element.nome_usuario,
              })
            });

          }
        );
    });
  }

}
