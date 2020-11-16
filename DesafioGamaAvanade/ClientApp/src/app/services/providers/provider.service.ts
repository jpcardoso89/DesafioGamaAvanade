import { environment } from '../../../environments/environment'
import { Inject } from '@angular/core';

export abstract class ProviderService {

  private urlBase: string;
  private API: string;

  constructor(api: string, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = `${baseUrl}`
    this.API = api;
  }

  get url() : string {
    return `${this.urlBase}${this.API}`;
  }

  urlOption(api: string): string {
    return `${this.urlBase}${api}`;
  }
}
