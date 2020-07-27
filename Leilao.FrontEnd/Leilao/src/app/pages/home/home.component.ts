import { Component, OnInit } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public user: any = {
    name: "",
    picture: "https://placehold.it/200",

  };

  constructor(
    private afAuth: AngularFireAuth,
  ) { }

  ngOnInit(): void {
    this.afAuth.user.subscribe((data) => {
      if (data) {
        this.user.name = data.displayName;
        this.user.picture = data.photoURL;
      }
    });
  }

  logout() {
    this.afAuth.signOut();
  }
}
