import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../_models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get('Customer');
  }

  createCustomer(customer: Customer) {
    return this.http.post('Customer', customer);
  }

  editCustomer(customer: Customer) {
    return this.http.put('Customer', customer);
  }

  deleteCustomer(id: number) {
    return this.http.delete(`Customer/${id}`);
  }

  getCustomerById(id: number) {
    return this.http.get(`Customer/${id}`);
  }

  getCustomerByCustomerRegister(register: string) {
    return this.http.get(`Customer/register/${register}`);
  }
  
}
