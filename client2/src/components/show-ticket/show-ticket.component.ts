import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field'
import { Ticket } from '../../models/ticket';
import { TicketService } from '../../services/ticket/ticket.service';

@Component({
  selector: 'app-show-ticket',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatSelectModule],
  templateUrl: './show-ticket.component.html',
  styleUrl: './show-ticket.component.css'
})
export class ShowTicketComponent {
  tickets: Ticket[] = [new Ticket('j', 'h', 'h', 'h')]
  constructor(private ticketService: TicketService) { }

  // async getTickets(): Promise<void> {
  //   (await this.ticketService.getTickets()).subscribe({
  //     next: (data: Ticket[]) => {
  //       this.tickets = data;
  //     },
  //     error: (error: any) => {
  //       console.error('Error fetching courses:', error);
  //     }
  //   })
  // }

  async changePassword(id: number, status: number) {
    (await this.ticketService.updateTicket(id, status)).subscribe({
      next: () => {
        alert('change password succeed')
      },
      error: (error: any) => {
        console.error('Error fetching courses:', error);
      }
    })
  }

  async deleteTicket(id:number){
    (await this.ticketService.deleteTicket(id)).subscribe({
      next: () => {
        alert('change password succeed')
      },
      error: (error: any) => {
        console.error('Error fetching courses:', error);
      }
    })
  }
}
