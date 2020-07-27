import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AngularFireAuth } from '@angular/fire/auth';
import { DataService } from 'src/app/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-leilao',
  templateUrl: './new-leilao.component.html',
  styleUrls: ['./new-leilao.component.css']
})
export class NewLeilaoComponent implements OnInit {
  public form: FormGroup;
  public itemLeilao = {
    nome_leilao: '',
    valor_inicial: null,
    item_usado: null,
    data_inicio: '',
    data_fim: '',
    status_leilao: true,
    User: '',
    nome_usuario: ''
  }
  public user: any = {
    name: ""

  };

  constructor(
    private fb: FormBuilder,
    private service: DataService,
    private router: Router,
    private afAuth: AngularFireAuth,
    private toastr: ToastrService,
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
  }

  // teste() {
  //   this.afAuth.idToken.subscribe(token => {
  //     this.service.getAllByUser(token)
  //       .subscribe(
  //         (data: any) => {

  //           console.log("funcionou!");
  //           console.log(data);

  //         }
  //       );
  //   });

  // }

  // teste() {
  //   this.afAuth.idToken.subscribe(token => {
  //     var obj = {
  //       method: 'GET',
  //       withCredentials: true,
  //       headers: {
  //         'Accept': 'application/json',
  //         'Content-Type': 'application/json',
  //         'Authorization': token
  //       }
  //     }

  //     fetch("https://localhost:44378/v1/leiloes/teste", obj)
  //       .then(function (res) {
  //         return res.json();
  //       })
  //       .then(function (resJson) {
  //         console.log(resJson);
  //       })
  //   });

  // }

  submit() {
    this.afAuth.idToken.subscribe(token => {
      this.itemLeilao.nome_leilao = this.form.value.nome_leilao;
      this.itemLeilao.item_usado = this.form.value.item_usado == "novo" ? true : false;
      this.itemLeilao.data_inicio = new Date(this.form.value.data_inicio).toJSON();
      this.itemLeilao.data_fim = new Date(this.form.value.data_fim).toJSON();
      this.itemLeilao.valor_inicial = Number(this.form.value.valor_inicial.toString().replace(",", "."));
      this.itemLeilao.nome_usuario = this.user.name;
      //this.itemLeilao.User = this.form.value.User;

      this.service.postLeilao(this.itemLeilao, token)
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

  cancelar() {
    if (confirm('Cancelar as mudanças?')) {
      this.itemLeilao = {
        nome_leilao: '',
        valor_inicial: null,
        item_usado: null,
        data_inicio: '',
        data_fim: '',
        status_leilao: true,
        User: '',
        nome_usuario: ''
      }
      this.router.navigateByUrl("/");
    }
  }
}
