import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { JobDocument } from '../../interfaces/JobDocument';
import { CommonModule } from '@angular/common';
import { CvDocument } from '../../interfaces/CvDocument';
import { JobService } from '../../services/job.service';
import { CvService } from '../../services/cv.service';

@Component({
  selector: 'job-input',
  templateUrl: './job-input.component.html',
  styleUrls: ['./job-input.component.scss'],
  imports: [FormsModule, CommonModule],
})
export class JobInputComponent {
  isLoadingJob: boolean = false;
  jobUrlInput: string = '';
  jobDocument: JobDocument | null = null;

  isLoadingCv: boolean = false;
  selectedFile: File | null = null;
  cvDocument: CvDocument | null = null;

  constructor(private jobService: JobService, private cvService: CvService) {}

  async onSubmit(): Promise<void> {
    if (!this.jobUrlInput) return;

    this.isLoadingJob = true;
    try {
      this.jobDocument = await this.jobService.getJobDocument(this.jobUrlInput);
    } catch (error) {
      console.error('Failed to fetch job document:', error);
    } finally {
      this.isLoadingJob = false;
    }
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

  async onFileSubmit(): Promise<void> {
    if (!this.selectedFile) {
      alert('Please select a file first.');
      return;
    }

    this.isLoadingCv = true;
    try {
      this.cvDocument = await this.cvService.getCvDocument(this.selectedFile);
    } catch (error) {
      console.error('Failed to fetch CV document:', error);
    } finally {
      this.isLoadingCv = false;
    }
  }
}
