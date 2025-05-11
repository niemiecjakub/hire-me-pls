import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'job-input',
  templateUrl: './job-input.component.html',
  styleUrls: ['./job-input.component.scss'],
  imports: [FormsModule],
})
export class JobInputComponent {
  jobUrlInput: string = '';
  jobContent: string = 'no-content';
  isLoading: boolean = false;

  constructor(private http: HttpClient) {}

  onSubmit(): void {
    this.fetchJobContent();
  }

  fetchJobContent(): void {
    this.isLoading = true;
    const apiUrl = 'https://localhost:32774/api/Job';

    const headers = new HttpHeaders({
      Accept: 'text/plain',
      'Content-Type': 'application/json',
    });

    this.http
      .post(apiUrl, `"${this.jobUrlInput}"`, { headers, responseType: 'text' })
      .subscribe(
        (response) => {
          this.isLoading = false;
          this.jobContent = response;
        },
        (error) => {
          console.error('Error:', error);
          this.jobContent = 'Failed to load content';
        }
      );
  }
}
