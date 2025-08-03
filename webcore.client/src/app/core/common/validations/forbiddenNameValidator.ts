import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

/** An actor's name can't match the given regular expression */
export function forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const forbidden = nameRe.test(control.value);
      return forbidden ? {forbiddenName: {value: control.value}} : null;
    };
  }