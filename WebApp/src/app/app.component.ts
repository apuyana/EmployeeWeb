import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeesService, IEmployee } from './services/employees.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  /**
   * Default Constructor.
   * @param formBuilder Form builder to use.
   * @param employeesService Employee service to use.
   */
  public constructor(
    public formBuilder: FormBuilder,
    @Inject(EmployeesService) public employeesService: EmployeesService) {

    this.isWorking = true;

    this.initForm();

    this.isWorking = false;
  }

  /**
   * Employee form
   */
  public employeeForm: FormGroup;

  /**
   * List of employees.
   */
  public employeeList: IEmployee[];

  /**
   * Flag for a submit attempt.
   */
  public submitAttempt: boolean = false;

  /**
   * Flag if there was an error.
   */
  public hasError: boolean = false;

  /**
   * Flag when the app is working.
   */
  public isWorking: boolean = false;

  /**
   * Titile for the page.
   */
  public title = 'webclient';

  // Send an email to the configurate email
  public async queryEmployees() {
    const self = this;
    self.submitAttempt = true;
    self.hasError = false;

    try {
      self.isWorking = true;

      if (self.employeeForm && self.employeeForm.valid) {

        let employeeId = self.employeeForm.controls['employeeId'].value;

        self.employeeList = await self.employeesService.getEmployeesAsync(employeeId);
      }
      else {
        self.hasError = true;
      }

    } catch (error) {
      console.error(error);
      self.hasError = true;
    }
    finally {
      self.isWorking = false;
    }
  }

  /**
   * Initilize login form.
   */
  public initForm() {
    this.employeeForm = this.formBuilder.group(
      {
        employeeId: new FormControl('', [Validators.maxLength(20)])
      });
  }
}