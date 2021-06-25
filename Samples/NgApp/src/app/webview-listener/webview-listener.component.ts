import {Component, OnDestroy, OnInit} from '@angular/core';

@Component({
  selector: 'app-webview-listener',
  templateUrl: './webview-listener.component.html',
})
export class WebviewListenerComponent implements OnInit, OnDestroy {
  listener: any;
  win = window as any;
  
  onClicked() {
    this.win.chrome.webview.postMessage('Button clicked');
  }

  ngOnInit(): void {
    this.listener = this.win.chrome.webview
    .addEventListener('message', (event: { data: any; }) => {
      alert(`Message received: ${event.data}`);
    });
  }

  ngOnDestroy(): void {
    this.win.chrome.webview.removeEventListener(this.listener);
  }
}
