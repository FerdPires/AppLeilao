import { Component, OnInit } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent implements OnInit {
  constructor(
    private afAuth: AngularFireAuth,
    private router: Router,
    private service: DataService,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.afAuth.onAuthStateChanged(data => {
      if (data) {
        this.afAuth.idToken.subscribe(
          token => {
            this.service.GetUser(token)
              .subscribe(
                (user: any) => {
                  if (!user.usuario_ativo) {
                    this.afAuth.signOut();
                    this.toastr.info("Usuário inativo!");
                  } else {
                    this.router.navigateByUrl('/');
                  }

                });
          });
      } else {
        this.router.navigateByUrl('/login');
      }
    });

    this.afAuth.idToken.subscribe(token => console.log(token));
  }
}
