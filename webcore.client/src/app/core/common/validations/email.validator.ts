import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

export function emailValidator(): ValidatorFn {
    const emailRe = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
    return (control: AbstractControl): ValidationErrors | null => {
      if(!control.value) {
        return null;
      }
      const invalid = emailRe.test(control.value);
      return !invalid ? {email: {value: control.value}} : null;
    };
  }