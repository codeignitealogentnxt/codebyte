import { environment } from '../environments/environment';

export class Configuration {
  constructor() {

  }

  public pageNo: number = 1;
  public pageSize: number = 10;
  public ServerAPIUrl = environment.Server + environment.APIUrl;
  public ImageUrl = environment.Server + '/';
  public TokenExpiryDays: 1;
  
}

export const DEFAULT_ERROR_MESSAGES = {
  alpha: 'This field is can only contain letters',
  alphaNumeric: 'This field can only contain letters or numbers',
  alphaNumericWithSpaces: 'This field can only contain letters or numbers',
  required: 'This field is required',
  numeric: 'This field must be a numeric value',
  minLength: 'You must enter at least {{1}} characters',
  maxLength: 'This field must be {{1}} characters or less',
  minDate: 'This field must be on or after {{1}}',
  maxDate: 'This field must be on or before {{1}}',
  minNumber: 'This field must be {{1}} or more',
  maxNumber: 'This field must be {{1}} or less',
  pastDate: 'This date must be before today',
  compare: 'This field must match "{{1}}"',
  notAllWhitespace: 'This field is required and must not be all whitespace',
  ssn: 'Must be 9 digits',
  zipCode: 'Must be a valid ZIP code',
  money: 'Must be an amount greater than $0.00',
  email: 'Must be a valid email format'
};

