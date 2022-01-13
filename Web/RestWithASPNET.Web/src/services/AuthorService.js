import axios from 'axios';

export default class AuthorServices {
    
    getAuthors() {
      return axios.get("https://localhost:44378/api/v1/authors");
    }
}