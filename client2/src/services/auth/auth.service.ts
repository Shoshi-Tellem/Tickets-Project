import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserService } from '../user/user.service';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = `https://localhost:7048/api/Auth`
  constructor(private http: HttpClient, private userService: UserService) { }

  async login(value: any): Promise<void> {
    try {
      const response: any = await firstValueFrom(this.http.post(`${this.url}`, value));
      console.log('User logged in successfully');
      this.userService.setUser(response);
    } catch (error) {
      console.error('Error logging in user', error);
      throw error
    }
  } 

  async signUp(value: any): Promise<void> {
    try {
      const response: any = await firstValueFrom(this.http.post(`${this.url}/register`, value));
      console.log('User signed up successfully', response);
      this.userService.setUser(response);
    } catch (error) {
      console.error('Error registering user', error);
      throw error;
    }
  }
  
}
