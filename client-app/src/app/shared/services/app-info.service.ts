import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const API_URL = 'http://localhost:5118/api/';

@Injectable()
export class AppInfoService {
  constructor(private http: HttpClient) { }

  public get(url: string, input: any = ''): Observable<any> {
    const options = input ? { params: new HttpParams().set('year', input) } : {};
    return this.http.get(API_URL + url, options); 
  }
  public patch(url: string, body: any): Observable<any> {
    return this.http.patch(API_URL + url, body); 
  }
}