import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-chat-window',
  standalone: true,
  templateUrl: './chat-window.component.html',
  styleUrl: './chat-window.component.scss',
  imports: [CommonModule, FormsModule], // Include CommonModule here
})
export class ChatWindowComponent {

  exampleQuestions: string[] = [
    'Tell me a fun fact about the Roman Empire',
    'What are some interesting inventions from the Renaissance era?',
    'Can you share a historical event from the Middle Ages?',
    // Add more example questions as needed
  ];
  
  sendMessage(message: string): void {
    // Handle sending the message
  }

  selectedQuestion: string | null = null; // Initialize as null

  // Function to handle button click and populate selected question
  selectQuestion(question: string): void {
    this.selectedQuestion = question;
  }
}
