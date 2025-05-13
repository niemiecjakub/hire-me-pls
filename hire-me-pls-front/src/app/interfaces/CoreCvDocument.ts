import { Education } from './Education';
import { OtherSection } from './OtherSection';
import { WorkExperience } from './WorkExperience';

export interface CoreCvDocument {
  aboutMe?: string;
  education: Education[];
  workExperience: WorkExperience[];
  skills: string[];
  languages: string[];
  otherSections: OtherSection[];
}
