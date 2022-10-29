import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class CompraDataService {

    module: string = '/api/compra';

    constructor(private http: HttpClient) { }

    realizarCompra(data) {
        return this.http.post(this.module, data);
    }

    getHistoricoComprasUsuario(usuarioId) {
        return this.http.get(this.module + '/GetHistoricoComprasUsuario' + '/' +  usuarioId);
    }
}