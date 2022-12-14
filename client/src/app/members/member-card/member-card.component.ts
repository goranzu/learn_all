import { Component, Input, OnInit } from '@angular/core';
import { IMember } from 'src/app/_models/IMember';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.scss'],
})
export class MemberCardComponent implements OnInit {
  @Input() member: IMember | null = null;

  constructor() {}

  ngOnInit(): void {}
}
