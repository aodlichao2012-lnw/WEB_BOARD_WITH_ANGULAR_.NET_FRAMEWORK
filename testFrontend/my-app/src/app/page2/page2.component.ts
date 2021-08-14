import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.css']
})
export class Page2Component implements OnInit {

  constructor() { }

  onepro = [{test : 0 , one: 'sssssssss'}, {test: 1 , one: "dddddddd"}]
  onetwo: any
  onetwo2: any
  output: any
  ngOnInit(): void {

    this.onetwo2 = JSON.stringify(this.onepro)
    console.log(this.onetwo2)
    this.onetwo = JSON.parse(this.onetwo2)
    this.output = this.onetwo2.one
  }

}
