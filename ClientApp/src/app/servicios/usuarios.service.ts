import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../usuarios/usuario';
import { UsuariosComponent } from '../usuarios/usuarios.component';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  baseUrl = "https://localhost:5001/api/Usuarios"

  constructor(private http: HttpClient) { }

  getUsuarios() {
    return this.http.get(`${this.baseUrl}`);
  }

  getMascota(id: string | number) {
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  addMascota(mascota: Usuario) {
    return this.http.post(`${this.baseUrl}/`, mascota);
  }

  deleteMascota(mascota: Usuario) {
    return this.http.delete(`${this.baseUrl}/${mascota.id}`);
  }

  update(id: number, usuario: Usuario): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, usuario);
  }
}
