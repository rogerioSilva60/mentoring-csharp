import axios from 'axios';

export default class BookServices {
    
    getBooks() {
      return axios.get("https://localhost:44378/api/v1/books");
    }
}