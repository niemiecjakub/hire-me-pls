import { Link } from './Link';

export interface PersonalDetails {
  name: string;
  phone: string;
  email: string;
  location: string;
  links: Link[];
}
