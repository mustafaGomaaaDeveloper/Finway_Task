import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({
  name: 'dateToAge',
})
export class DateToAgePipe implements PipeTransform {
  transform(value: any): string {
    let today = moment();
    let birthdate = moment(value);
    let years = today.diff(birthdate, 'years');
    let html: string = years + '';
    return html;
  }
}
