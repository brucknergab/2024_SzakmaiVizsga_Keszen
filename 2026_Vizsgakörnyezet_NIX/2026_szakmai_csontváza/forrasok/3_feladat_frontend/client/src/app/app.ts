import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from './services/service';
import { Model } from './models/model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  
  items: Model[] = [];
  errorMessage: string = '';
  searchId: number | null = null;
  searchGyarto: string = '';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {

  }

  loadById(): void {
    if (!this.searchId) {
      return
    }
    this.apiService.getById(this.searchId).subscribe({
      next: (data) => {
        this.items = [data];
        this.errorMessage = "";
      },
      error: (err) => {
        if (err instanceof ProgressEvent) {
          this.errorMessage = "Nem tudtunk csatlakozni a szerverhez.";
        }
        else {
          this.errorMessage = "Nincs ilyen Id-val rendelkező rekord az adatbázisban:" + this.searchId + " (404)";
        }
        this.items = [];
      }
    })
  }

  loadAll(): void {
    this.apiService.getAll().subscribe({
      next: (data) => {
        this.items = data;
        this.errorMessage = "";
      },
      error: (err) => {
        this.errorMessage = "Nincs adat az adatbázisban!" + err;
        this.items = [];
      }
    })
  }

  loadByGyarto(): void {
    this.apiService.getAllByGyarto(this.searchGyarto).subscribe({
      next: (data) => {
        this.items = data;
        this.errorMessage = "";
      },
      error: (err) => {
        this.errorMessage = "Nincs ilyen gyártójú rekord az adatbázisban: ${this.searchGyarto} (404)";
        this.items = [];
      }
    })
  }


}