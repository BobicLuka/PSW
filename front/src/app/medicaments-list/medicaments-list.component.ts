import { Component, OnInit } from '@angular/core';
import { MedicamentService } from '../services/medicamentService';



export interface Medicament {
  id: number,
  quantity: number
}

@Component({
  selector: 'app-medicaments-list',
  templateUrl: './medicaments-list.component.html',
  styleUrls: ['./medicaments-list.component.scss']
})
export class MedicamentsListComponent implements OnInit {

    displayedColumns: string[] = ['name', 'quantity'];
    elements: any;
  
    constructor(private medicamentService: MedicamentService) { }
  
    ngOnInit(): void {
  
      this.elements = [];

      this.medicamentService.getMedicaments().subscribe(result => {
  
        this.elements = result;
      });
    }
  
  }
