import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AngularFireAuth } from '@angular/fire/auth';
import { DataService } from 'src/app/data.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-leiloes',
  templateUrl: './user-leiloes.component.html',
  styleUrls: ['./user-leiloes.component.css']
})
export class UserLeiloesComponent implements OnInit {
  public form: FormGroup;
  editing: false;
  columns = ["Id", "Nome do Leilão", "Valor Inicial", "Tipo do item", "Status do Leilão", "Usuário responsável"];
  index = ["Id", "nome_leilao", "valor_inicial", "item_usado", "status_leilao", "nome_usuario"];

  public itemLeilaoList = [{
    "Id": "",
    "nome_leilao": "",
    "valor_inicial": "",
    "item_usado": "",
    "status_leilao": "",
    "nome_usuario": "",
  }];

  public itemLeilao = {
    Id: null,
    nome_leilao: '',
    valor_inicial: null,
    item_usado: null,
    data_inicio: '',
    data_fim: '',
    User: '',
  }
  public user: any = {
    name: ""

  };

  constructor(
    private fb: FormBuilder,
    private service: DataService,
    private router: Router,
    private afAuth: AngularFireAuth,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      nome_leilao: '',
      valor_inicial: null,
      item_usado: '',
      data_inicio: '',
      data_fim: '',
      User: ''
    });
  }

  ngOnInit(): void {
    this.afAuth.user.subscribe((data) => {
      if (data) {
        this.user.name = data.displayName;
      }
    });

    this.itemLeilaoList = [];
    this.afAuth.idToken.subscribe(token => {
      this.service.getAllByUser(token)
        .subscribe(
          (data: any) => {
            data.forEach(element => {
              this.itemLeilaoList.push({
                "Id": element.id,
                "nome_leilao": element.nome_leilao,
                "valor_inicial": element.valor_inicial.toString().replace(".", ","),
                "item_usado": element.item_usado ? "Novo" : "Usado",
                "status_leilao": new Date(element.data_fim).getTime() < new Date().getTime() ? "Desativo" : "Ativo",
                "nome_usuario": element.nome_usuario
              })
            });
          }
        );
    });
  }

  delete(data: any) {
    if (confirm('Deseja realmente excluir esse leilão?')) {
      this.afAuth.idToken.subscribe(token => {
        this.service.deleteLeilao(data.Id, token)
          .subscribe((res: any) => {
            if (res.success) {
              this.toastr.success(res.message);
            } else {
              this.toastr.error(res.message);
            }
            this.router.navigateByUrl("/");
          });
      });
    }
  }

  edit(data: any) {
    this.afAuth.idToken.subscribe(token => {

      this.service.getById(data.Id, token)
        .subscribe(
          (data: any) => {
            this.form = this.fb.group({
              Id: data.id,
              nome_leilao: data.nome_leilao,
              valor_inicial: data.valor_inicial.toString().replace(".", ","),
              item_usado: data.item_usado == true ? "novo" : "usado",
              data_inicio: new Date(data.data_inicio).toJSON().substring(0, 16),
              data_fim: new Date(data.data_fim).toJSON().substring(0, 16),
              User: ''
            });
          });
    });
  };

  update() {
    this.afAuth.idToken.subscribe(token => {
      this.itemLeilao.Id = this.form.value.Id;
      this.itemLeilao.nome_leilao = this.form.value.nome_leilao;
      this.itemLeilao.item_usado = this.form.value.item_usado == "novo" ? true : false;
      this.itemLeilao.data_inicio = new Date(this.form.value.data_inicio).toJSON();
      this.itemLeilao.data_fim = new Date(this.form.value.data_fim).toJSON();
      this.itemLeilao.valor_inicial = Number(this.form.value.valor_inicial.toString().replace(",", "."));
      this.itemLeilao.User = this.form.value.User;
      this.service.putLeilao(this.itemLeilao, token)
        .subscribe((res: any) => {
          if (res.success) {
            this.toastr.success(res.message);
          } else {
            this.toastr.error(res.message);
          }
          this.router.navigateByUrl("/");
        });
    });
  }

  cancel() {
    if (confirm('Cancelar as mudanças?')) {
      this.form = this.fb.group({
        nome_leilao: '',
        valor_inicial: null,
        item_usado: '',
        data_inicio: '',
        data_fim: '',
        User: ''
      });
      this.itemLeilao = {
        Id: null,
        nome_leilao: '',
        valor_inicial: null,
        item_usado: null,
        data_inicio: '',
        data_fim: '',
        User: ''
      }
    }
  }
}
