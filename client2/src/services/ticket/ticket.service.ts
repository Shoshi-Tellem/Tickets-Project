import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../../models/ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  constructor(private http: HttpClient) { }
  private url = 'https://localhost:7048/api/Ticket'

  async getTickets() {
    return await this.http.get<Ticket[]>(this.url)
  }

  async getTicketById(id: string) {
    return await this.http.get(`${this.url}/${id}`)
  }

  async createTicket(fullName: string, email: string, description: string, imageUrl: string) {
    const body = { fullName, email, description, imageUrl }
    return await this.http.post(this.url, body)
  }

  async updateTicket(id: number, status: number) {
    return await this.http.put(`${this.url}/${id}`, status);
  }

  async deleteTicket(id: number) {
    return await this.http.delete(`${this.url}/${id}`);
  }
}
