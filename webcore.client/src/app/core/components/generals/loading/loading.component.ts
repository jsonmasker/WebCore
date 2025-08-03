import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import {
  ModalBodyComponent,
  ModalComponent,
} from '@coreui/angular';
import { LoadingService } from '@services/helper-services/loading.service';
@Component({
  selector: 'app-loading',
  imports: [ModalComponent,ModalBodyComponent],
  templateUrl: './loading.component.html',
  styleUrl: './loading.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class LoadingComponent implements OnInit {
  progress : number = 0;
  @Input() visible : boolean = false;
  
  constructor(private loadingService: LoadingService) {
  }
  ngOnInit(): void {
    this.loadingService.visible$.subscribe(({ show }) => {
      this.visible = show;
      if(show){
        this.updateProgress();
      }
    });
  }

  handleLiveDemoChange(event: any) {
    this.progress = 0;
    if(event){
      this.updateProgress();
    }
  }

  updateProgress(): void {
     if (this.progress < 100 && this.visible) {
        setTimeout(() => {
          if(this.progress < 100) {
            this.progress += 5;
            this.updateProgress();
          }
        }, 200);
     }
  }
}
