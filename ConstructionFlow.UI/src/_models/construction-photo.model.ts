import { Construction } from "./construction.model";

export interface ConstructionPhoto {
  id?: number;
  constructionId?: number;
  photo: string;
  construction?: Construction;
}
