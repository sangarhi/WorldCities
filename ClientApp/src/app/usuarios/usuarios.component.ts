import { Component, OnInit } from '@angular/core';
import { UsuariosService } from '../servicios/usuarios.service';
import { Usuario } from './usuario';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuariosList: any;
  user: Usuario;

  constructor(public _usuariosService: UsuariosService) { }

  ngOnInit() {
    this._usuariosService.getUsuarios().subscribe(data => {this.usuariosList = data});
  }

  // updateTutorial(): void {
  //   this._usuariosService.update(this.user.id, this.user)
  //     .subscribe(
  //       response => {
  //         console.log(response);
  //       },
  //       error => {
  //         console.log(error);
  //       });
  // }
  onChangeEvent(event: any, id) {
    this.user = new Usuario();
    this.user.email = event.target.value;
    this.user.id = id;
    //this.user.nombre ="";
    //this.user.apellido ="";
    //this.user.genero ="";
    console.log(this.user.email);

    console.log(event.target.value);
    this._usuariosService.update(id, this.user)
      .subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.log(error);
        });
    
   //this.updateTutorial();
  }

}
