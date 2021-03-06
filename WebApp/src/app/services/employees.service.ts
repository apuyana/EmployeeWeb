import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { first } from 'rxjs/operators';

/**
 * Interface for the star limit.
 */
export interface IEmployee {
  Id: number;
  Name: string;
  AnnualSalary: number;
  RoleName?: string;
}

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  /**
     * Get the leader board score for a track.
     * @param videoId Video id.
     */
  public getEmployeesAsync(employeeId: number): Promise<IEmployee[]> {
    const self = this;
    const promise = new Promise<IEmployee[]>(
      async (resolve, reject) => {
        let results: IEmployee[] = new Array(0);
        try {
          const self = this;
          const apiUrl = environment.apiUrl;
          if (employeeId) {
            const remoteResult: any = await self.http.get(`${apiUrl}/${employeeId}`).pipe(first()).toPromise();
            if(remoteResult){
              results.push(remoteResult);
            }            
          }
          else {
            const remoteResults: any = await self.http.get(apiUrl).pipe(first()).toPromise();
            results = remoteResults;
          }

          resolve(results);

        } catch (error) {
          reject(error);
        }
      });

    return promise;
  }
}
