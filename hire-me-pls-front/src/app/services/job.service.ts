import { Injectable } from '@angular/core';
import { JobDocument } from '../interfaces/JobDocument';
import { API_BASE_URL } from '../config/api.config';

@Injectable({
  providedIn: 'root',
})
export class JobService {
  constructor() {}

  getJobDocument(jobUrl: string): Promise<JobDocument> {
    console.log('Fetching job document from URL:', jobUrl);

    const apiUrl = `${API_BASE_URL}/Job`;
    const headers = new Headers({
      Accept: 'text/plain',
      'Content-Type': 'application/json',
    });

    return fetch(apiUrl, {
      method: 'POST',
      headers: headers,
      body: `"${jobUrl}"`,
    })
      .then((response) => response.json())
      .catch((error) => {
        console.error('Error:', error);
        throw error;
      });
  }
}
