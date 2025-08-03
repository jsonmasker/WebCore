import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';
import { chatbotHubUrl, streamOllamaUrl } from '@common/global';
@Component({
  selector: 'app-stream-ollama',
  imports: [CommonModule, FormsModule],
  templateUrl: './stream-ollama.component.html',
  styleUrl: './stream-ollama.component.scss'
})

export class StreamOllamaComponent implements OnInit,OnDestroy {
  messages: { sender: string, text: string }[] = [];
  userInput: string = '';
  data: string = '';
  index: number = 0;
  text: string = '';
  loading: boolean = false;
  request: FormGroup = new FormGroup({
    request: new FormControl(''),
    model: new FormControl('gemma3'),
    response: new FormControl(''),
    context: new FormControl([]),
    stream: new FormControl(false)
  });
  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl(chatbotHubUrl)
    .build();

  constructor(private http: HttpClient) { }
  ngOnDestroy(): void {
    this.stopConnection();
  }
  ngOnInit(): void {
    this.startConnection();
    this.addListener('ReceiveMessage', (message: string, context: any) => {
      this.loading = false;
      this.messages[this.index].text += message;
      this.text += message.replace(/<br\s*\/?>/gi, '\n');
      if(context){
        this.request.patchValue({
          context: context
        });
      }
        
    });
  }

  sendMessage(): void {
    if (this.userInput.trim()) {
      this.messages.push({ sender: 'User', text: this.userInput });
      this.request.patchValue({
        request: this.userInput
      });
      this.userInput = '';
      this.loading = true;
      this.http.post(streamOllamaUrl, this.request.value).subscribe(() => {
        this.messages.push({ sender: 'Bot', text: '' });
        this.index = this.messages.length - 1;
        this.text = '';
        console.log('completed request');
      });
    }
  }
  //#region SignalR
  private startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch((err: any) => console.log('Error while starting SignalR connection: ' + err));
  }

  private addListener(eventName: string, callback: (...args: any[]) => void): void {
    if (this.hubConnection) {
      this.hubConnection.on(eventName, callback);
    }
  }

  private stopConnection(): void {
    if (this.hubConnection) {
      this.hubConnection.stop()
        .then(() => console.log('SignalR connection stopped'))
        .catch((err: any) => console.log('Error while stopping SignalR connection: ' + err));
    }
  }
  //#endregion
}