import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './assets/styles/main.css'

import { BrowserRouter } from 'react-router-dom'
import { AppStorage } from './assets/utilities/storage.ts'
import { Provider } from 'react-redux'
import store from './store/index.ts'
import { Toaster } from 'react-hot-toast'

// App configurations
AppStorage.Provider = localStorage;

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <BrowserRouter>
      <Provider store={store}>
        <Toaster/>
        <App />
      </Provider>
    </BrowserRouter>
  </React.StrictMode>,
)
