import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

export function fullNameValidator(): ValidatorFn {
    // FullName don't allow special characters.
    // FullName don't allow numbers.
    // FullName have limited length 3 to 50 characters.
    const fullNameRe = /^[\p{L}\p{M}\s]{3,50}$/u;
    return (control: AbstractControl): ValidationErrors | null => {
      const invalid = !fullNameRe.test(control.value);
      return invalid ? {fullname: {value: control.value}} : null;
    };
}