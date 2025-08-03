import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

export function userNameValidator(): ValidatorFn {
    // UserName must be between 6 and 50 characters, contain no spaces, and not be null.
    const usernameRe = /^[a-zA-Z\d]{6,50}$/;

    return (control: AbstractControl): ValidationErrors | null => {
        const value = control.value;

        // Check for null or empty value
        if (!value) {
            return { userName: { required: true } };
        }

        // Check for valid format
        const valid = usernameRe.test(value);
        console.log(valid ? null : { userName: { value } });
        return valid ? null : { userName: { value } };
    };
}
