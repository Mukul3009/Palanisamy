import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Employee } from './employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = "http://localhost:64091/Api/Employee";

  constructor(private http: HttpClient) { }

  getAllEmployees()
  {
    return this.http.get<Employee[]>(this.url + "/AllEmployees");
  }

  getEmployeeById(employeeId: string): Observable<Employee>
  {
return this.http.get<Employee>(this.url + "/GetEmployeeById/" + employeeId);
  }
  createEmployee(employee:Employee) : Observable<Employee>
  {
    const httpOptions = {headers: new HttpHeaders({ 'Content-Type' : 'application/json'})};
    return this.http.post<Employee>(this.url + "/InsertEmployees/",employee,httpOptions);
  }
  updateEmployee(employee:Employee) : Observable<Employee>
  {
    const httpOptions = {headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.put<Employee>(this.url + "/UpdateEmployees/",employee,httpOptions);
  }
  deleteEmployeeById(employeeId:string) : Observable<number>
  {
    const httpOptions = {headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this.http.delete<number>(this.url + "/DeleteEmployee?id=" + employeeId,httpOptions);
  }
}
