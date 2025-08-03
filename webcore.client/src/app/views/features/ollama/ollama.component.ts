import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ollamaUrl } from '@common/global';


@Component({
  selector: 'app-ollama',
  imports: [CommonModule, FormsModule],
  templateUrl: './ollama.component.html',
  styleUrl: './ollama.component.scss'
})
export class OllamaComponent {
 messages: { sender: string, text: string }[] = [];
  userInput: string = '';
  loading: boolean = false;
  request: FormGroup = new FormGroup({
    request: new FormControl(''),
    model: new FormControl('gemma3'),
    response: new FormControl(''),
    context: new FormControl([]),
    stream: new FormControl(false)
  });

  constructor(private http: HttpClient) { }


  sendMessage(): void {
    if (this.userInput.trim()) {
      this.messages.push({ sender: 'User', text: this.userInput });
      this.request.patchValue({
        request: this.userInput
      });
      this.userInput = '';
      this.loading = true; // Start loading animation

      this.http.post(ollamaUrl, this.request.value).subscribe((result: any) => {
        this.messages.push({ sender: 'Bot', text: result.response.replace(/\n/g, '<br/>') });
        console.log('Response:', result.response);
        this.request.patchValue({
          context: result.context
        });
        this.loading = false; // Stop loading animation
      }
      , (error) => {
        console.error('Error:', error);
        this.messages.push({ sender: 'Bot', text: 'Sorry, I could not process your request.' });
        this.loading = false; // Stop loading animation
      });    
    }
  }
}