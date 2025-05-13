import { Injectable } from '@angular/core';
import { API_BASE_URL } from '../config/api.config';
import { CvDocument } from '../interfaces/CvDocument';

@Injectable({
  providedIn: 'root',
})
export class CvService {
  constructor() {}

  getCvDocument(file: File): Promise<CvDocument> {
    const apiUrl = `${API_BASE_URL}/Cv`;
    const formData = new FormData();
    formData.append('file', file);

    return fetch(apiUrl, {
      method: 'POST',
      body: formData,
    })
      .then((response) => response.json())
      .catch((error) => {
        console.error('Error:', error);
        throw error;
      });
  }
}
