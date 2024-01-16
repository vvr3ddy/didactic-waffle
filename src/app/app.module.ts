// src/app/app.module.ts

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, // AppRoutingModule should be imported here
    CommonModule
  ],
  providers: [],
  bootstrap: []
})
export class AppModule { }
