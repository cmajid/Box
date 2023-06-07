import axios from "axios";
import { AppStorage } from "./storage";

export const axiosDownloadFile= (url: string, fileName:string)=>  {
    return axios({
      url,
      headers : { Authorization: `Bearer ${AppStorage.Provider.getItem('token')}`},
      method: 'GET',
      responseType: 'blob',
    })
      .then(response => {
        const href = window.URL.createObjectURL(response.data);
  
        const anchorElement = document.createElement('a');
  
        anchorElement.href = href;
        anchorElement.download = fileName;
  
        document.body.appendChild(anchorElement);
        anchorElement.click();
  
        document.body.removeChild(anchorElement);
        window.URL.revokeObjectURL(href);
      })
      .catch(error => {
        console.log('error: ', error);
      });
  }