import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormat'
})
export class DateTimeFormatPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.transform(value, 'dd/MM/yyyy');
  }

}
