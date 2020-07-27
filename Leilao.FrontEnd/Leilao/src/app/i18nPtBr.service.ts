import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class I18nPtBrService {

  public localeTextAgGrid = {
    filterOoo: 'Filtrar ...',
    notEqual: 'Não igual',
    equals: 'Igual',
    lessThan: 'Menor que',
    greaterThan: 'Maior que',
    contains: 'Contém',
    notContains: 'Não contém',
    startsWith: 'Começa com',
    endsWith: 'Termina com',
    noRowsToShow: 'Sem resultados!',
  };

  constructor() { }
}

