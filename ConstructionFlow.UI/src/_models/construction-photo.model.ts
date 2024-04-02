import { Construction } from "./construction.model";

export interface ConstructionPhoto {
  constructionPhotoId: string,
  construction: Construction,
  photo: string
}
