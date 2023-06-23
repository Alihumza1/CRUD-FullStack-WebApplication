import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoggingService {

  constructor(private http: HttpClient) { }

  log(message: string, level: string) {
    const logData = {
      timestamp: new Date(),
      level: level,
      message: message
    };

    this.http.post('https://localhost:7149/api/Logging', logData).subscribe();
  }
}
