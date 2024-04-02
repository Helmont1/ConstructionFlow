import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user.model';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  // user: User = {} as User;
  ngOnInit() {
  //   this.user = JSON.parse(sessionStorage.getItem('user') || '{}');
  }
}
