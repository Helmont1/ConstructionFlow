import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  MatDialog,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
  MatSelect,
} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';


@Component({
  selector: 'app-activity-modal',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatSelectModule],
  templateUrl: './activity-modal.component.html',
  styleUrl: './activity-modal.component.scss'
})
export class ActivityModalComponent {
  constructor(
    public dialogRef: MatDialogRef<ActivityModalComponent>
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
