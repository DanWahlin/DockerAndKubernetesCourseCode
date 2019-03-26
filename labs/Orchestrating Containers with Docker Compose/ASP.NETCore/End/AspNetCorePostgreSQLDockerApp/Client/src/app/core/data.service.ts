import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { ICustomer } from '../shared/interfaces';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    
    private url: string = 'api/customersservice/customers/';
    
    constructor(private http: HttpClient) { }
    
    getCustomersSummary() : Observable<ICustomer[]> {
        return this.http.get<ICustomer[]>(this.url)
            .pipe(
                catchError(this.handleError)
            );
    }
    
    updateCustomer(customer: ICustomer) {       
      return this.http.put(this.url + customer.id, customer)
                .pipe(
                    catchError(this.handleError)
                );
    }
    
    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    
}
