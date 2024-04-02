import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Construction } from "../_models/construction.model";

@Injectable(
  { providedIn: 'root' }
)
export class ConstructionService {
  url = 'Construction'

  constructor(private http: HttpClient) { }

  getConstructionsByUser() {
    return this.http.get(`${this.url}/user`);
  }

  createConstruction(construction: Construction) {
    return this.http.post(this.url, construction);
  }

  editConstruction(construction: Construction) {
    return this.http.put(`${this.url}/${construction.constructionId}`, construction);
  }

  deleteConstruction(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
