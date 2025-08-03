import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { CardBodyComponent, CardComponent } from '@coreui/angular';
import { HttpClient } from '@angular/common/http';
//import { ChatbotService } from '@services/feature-services/chatbot.service';
import { SignalRService } from '@services/signalr.service';
import { EUrl } from '@common/url-api';

@Component({
  selector: 'app-ai-chatbot',
  imports: [CommonModule, FormsModule],
  templateUrl: './ai-chatbot.component.html',
  styleUrl: './ai-chatbot.component.scss'
})
export class AiChatbotComponent implements OnInit{
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
  data: string = '';

  constructor(
    public signalRService: SignalRService,
    private http: HttpClient) { }
  ngOnInit(): void {
    this.signalRService.startConnection(); 
    this.signalRService.addListener('ReceiveMessage', (message: string) => {
      //console.log('Received message:', message);
       this.loading = false; // Stop loading animation 
      this.data += message.replace(/<br\s*\/?>/gi, '\n');
    });
  }

  sendMessage(): void {
    if (this.userInput.trim()) {
      this.messages.push({ sender: 'User', text: this.userInput });
      this.request.patchValue({
        request: this.userInput
      });
      this.userInput = '';
      this.loading = true; // Start loading animation
      // this.chatbotService.getResponse(this.request.value).subscribe((result: any) => {
      //   this.messages.push({ sender: 'Bot', text: result.response.replace(/\n/g, '<br/>') });
      //   console.log('Response:', result.response);
      //   this.request.patchValue({
      //     context: result.context
      //   });
      //   this.loading = false; // Stop loading animation
      // }
      // , (error) => {
      //   console.error('Error:', error);
      //   this.messages.push({ sender: 'Bot', text: 'Sorry, I could not process your request.' });
      //   this.loading = false; // Stop loading animation
      // });
      this.http.post('', this.request.value).subscribe(()=>{
        this.messages.push({ sender: 'Bot', text: this.data });
        this.data = '';
        console.log('completed request');
      });
    }
  }
}
