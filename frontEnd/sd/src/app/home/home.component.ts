import { Component } from '@angular/core';
import { CustomerService } from '../customer.service'; 

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  customers: any[] = [];
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data;
    });
  }

  viewOrders(customerId: number): void {
    // Lógica para abrir el modal de OrdersView
  }

  newOrder(customerId: number): void {
    // Lógica para abrir el modal de NewOrder
  }
}
