import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

export function passwordValidator(): ValidatorFn {
    /*
    It must contain at least one lowercase letter ((?=.*[a-z])).
    It must contain at least one uppercase letter ((?=.*[A-Z])).
    It must contain at least one digit ((?=.*\d)).
    It must be at least 8 characters long ([a-zA-Z\d]{8,}).
    */
    const passwordRe = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,20}$/;

    //Password must not be null.
    //Password must not contain spaces.
    //Password length must be between 6 and 20 characters.
    //const passwordRe = /^(?!.*\s)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,20}$/;

    return (control: AbstractControl): ValidationErrors | null => {
      const invalid = passwordRe.test(control.value);
      return invalid ? null : {password: {value: control.value}};
    };
  }