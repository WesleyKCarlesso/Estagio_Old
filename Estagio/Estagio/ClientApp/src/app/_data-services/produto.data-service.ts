import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class ProdutoDataService {

    module: string = '/api/produto';

    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get(this.module)
    }

    post(data) {
        return this.http.post(this.module, data)
    }

    put(data) {
        return this.http.put(this.module, data)
    }

    delete(produtoId) {
        return this.http.delete(this.module + '/' + produtoId)
    }
    
    getProdutosParaCompra() {
        return this.http.get(this.module + "/getProdutosParaCompra")
    }
}