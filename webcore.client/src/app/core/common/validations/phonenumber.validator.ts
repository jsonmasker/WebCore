import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

const startPhoneNumber: string[] = [
    //Viettel
    "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039",
    //Vinaphone
    "088", "091", "094", "083", "084", "085", "081", "082",
    //Mobifone
    "089", "090", "093", "070", "079", "077", "076", "078",
    //Vietnamobile
    "092", "056", "058", "052", "059",
    //Gmobile
    "099", "059",
    //Itelecom
    "087"
];

function isValidPhoneNumber(phoneNumber: string): boolean {
    if (phoneNumber.length < 10 || phoneNumber.length > 11) {
        return false;
    }
    const startDigits = phoneNumber.substring(0, 3); // Get the first three digits of the phone number
    return startPhoneNumber.includes(startDigits);
}

export function phoneNumberValidator(): ValidatorFn {
    const phoneNumberRe = /^[0-9]*$/;
    return (control: AbstractControl): ValidationErrors | null => {
        if (!control.value) {
            return null;
        }
        const invalid = phoneNumberRe.test(control.value) &&  isValidPhoneNumber(control.value);   
        return !invalid ? { phoneNumber: { value: control.value } } : null;
    };
}