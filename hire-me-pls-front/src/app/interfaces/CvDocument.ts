import { CoreCvDocument } from './CoreCvDocument';
import { PersonalDetails } from './PersonalDetails';

export interface CvDocument extends CoreCvDocument {
  personalDetails: PersonalDetails;
}
