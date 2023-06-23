import { ErrorHandler, Injectable } from '@angular/core';
import { LoggingService } from 'src/app/services/logging.service';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private loggingService: LoggingService) {}

  handleError(error: any): void {
    const message = 'An error occurred: ' + error.message;
    const level = 'ERROR';
    this.loggingService.log(message, level);
    throw error;
  }
}
