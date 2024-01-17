import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Message } from '../../models/message.model';

@Component({
  selector: 'app-chat-window',
  standalone: true,
  templateUrl: './chat-window.component.html',
  styleUrl: './chat-window.component.scss',
  imports: [CommonModule, FormsModule], // Include CommonModule here
})
export class ChatWindowComponent {

  showAreaElement: boolean = true;
  userInput: string = '';
  exampleQuestions: string[] = [
    'Tell me a fun fact about the Roman Empire',
    'What are some interesting inventions from the Renaissance era?',
    'Can you share a historical event from the Middle Ages?',
    // Add more example questions as needed
  ];
  chatMessages: Message[] = []; // Array to store chat messages


  sendMessage(message: string): void {
    // Handle sending the message
  }

  selectedQuestion: string | null = null; // Initialize as null

  // Function to handle button click and populate selected question
  selectQuestion(question: string): void {
    this.selectedQuestion = question;
  }

  // Function to send a user message
  sendUserMessage(): void {
    if (this.selectedQuestion !== null || this.userInput.trim() !== '') {
      const userMessage: Message = {
        content: (this.userInput.trim() !== '' ? this.userInput.trim() : this.selectedQuestion ?? ''),
        sender: 'user',
        timestamp: new Date(),
      };

      this.chatMessages.push(userMessage);

      // Clear the user input
      this.userInput = '';

      // Clear the selected question
      this.selectedQuestion = null;

      // Simulate bot response after each user message
      this.simulateBotResponse();
      this.showAreaElement = false;
    }
  }

  // Function to simulate bot response (for demonstration purposes)
  simulateBotResponse(): void {
    const botMessage: Message = {
      content: 'This is a bot response.',
      sender: 'bot',
      timestamp: new Date(),
    };

    this.chatMessages.push(botMessage);
  }
}
