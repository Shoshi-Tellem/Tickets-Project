import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Ticket } from '../../models/ticket';
import { TicketService } from '../../services/ticket/ticket.service';

@Component({
  selector: 'app-ticket',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule],
  templateUrl: './ticket.component.html',
  styleUrl: './ticket.component.css'
})
export class TicketComponent {
  addTicketForm!: FormGroup;
  constructor(private ticketService: TicketService, private fb: FormBuilder) { }

  ngOnInit() {
    this.addTicketForm = this.fb.group({
      ticketGroup: this.fb.group({
        name: ['', Validators.required],
        email: ['', Validators.email, Validators.required],
        description: ['', Validators.required],
        image: ['', Validators.required],
      }),
    });
  }

  async onSubmit() {
    if (this.addTicketForm.valid) {
      const ticket: Ticket = this.addTicketForm.value.ticketGroup
      const { fullName, email, description, imageUrl } = ticket
      await this.ticketService.createTicket(fullName, email, description, imageUrl)
    }
  }
}
