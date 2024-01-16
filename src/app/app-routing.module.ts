import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatWindowComponent } from './component/chat-window/chat-window.component'; // Import the component

const routes: Routes = [
  { path: '', component: ChatWindowComponent }, // Define a route that uses ChatWindowComponent
  // Define other routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
