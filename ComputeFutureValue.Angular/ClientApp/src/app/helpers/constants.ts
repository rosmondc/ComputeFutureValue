import { HttpHeaders } from "@angular/common/http";

export const API_URL = `https://localhost:5001/api`;


export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
