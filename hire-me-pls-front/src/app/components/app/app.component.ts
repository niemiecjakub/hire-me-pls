import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JobInputComponent } from '../job-input/job-input.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { JobService } from '../../services/job.service';
import { CvService } from '../../services/cv.service';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    JobInputComponent,
    HttpClientModule,
    FormsModule,
  ],
  providers: [JobService, CvService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'hire-me-pls-front';
}
