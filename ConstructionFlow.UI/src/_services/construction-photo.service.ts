import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstructionPhotoService {
  url = 'ConstructionPhoto'
  constructor(private http: HttpClient) { }

  getPhotosById(id: number) {
    return this.http.get(`${this.url}/${id}`);
  }
  getPhotosByConstructionId(id: number) {
    return this.http.get(`${this.url}/construction/${id}`);
  }
  createPhoto(photo: any) {
    return this.http.post(this.url, photo);
  }
  deletePhoto(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
  updatePhoto(photo: any) {
    return this.http.put(`${this.url}`, photo);
  }
}
