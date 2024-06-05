import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Status } from '../../_models/status.model';
import { Activity } from '../../_models/activity.model';
import { FormsModule } from '@angular/forms';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { Construction } from '../../_models/construction.model';

@Component({
  selector: 'app-construction-list',
  standalone: true,
  imports: [
    FormsModule,
    NgxMaskDirective,
    NgxMaskPipe
  ],
  templateUrl: './construction-list.component.html',
  styleUrl: './construction-list.component.scss'
})
export class ConstructionListComponent {
  @Input() show: boolean = false;
  @Input() constructions: Construction[] = [];
  @Output() choosed = new EventEmitter<Construction>();
  @Output() closed = new EventEmitter<void>();

  choose(construction: Construction) {
    this.choosed.emit(construction);
    this.constructions = [];
  }

}
