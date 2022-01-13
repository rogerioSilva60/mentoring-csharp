<template>
  <div class="d-menubar">
    <Menubar :model="items">
      <template #start>
        <img alt="logo" src="https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png" height="40" class="p-mr-2">
      </template>
    </Menubar>
  </div>
  <div class="content">
    <div class="card-content">
      <Card>
        <template #title>
          <h1>Books</h1>
        </template>
        <template #content> 
          <div class="content-filter">
            <span class="p-field">
              <h5>Id</h5>
              <InputText id="id" type="text" v-model="id" disabled />
            </span>
            <span class="p-field">
              <h5>Title</h5>
              <InputText id="title" type="text" v-model="title" />
            </span>
            <span class="p-field">
              <h5>Price</h5>
              <InputNumber id="price" v-model="price" />
            </span>
            <span class="p-field">
              <h5>Authors</h5>
              <Dropdown 
                v-model="selectedAuthor" 
                :options="optionsAuthors" 
                optionLabel="name"  
                placeholder="Select a Author" 
              />
            </span>
          </div> 
          <div class="d-button">
            <Button label="Save" @click="save"/>
          </div>    
        </template>
      </Card>
    </div>
    
    <div class="d-datatable">
      <DataTable :value="bookList" :scrollable="true" scrollHeight="400px" responsiveLayout="scroll">
        <Column field="id" header="ID"></Column>
        <Column field="title" header="Title"></Column>
        <Column field="price" header="Price"></Column>
        <Column field="author.name" header="Author"></Column>
      </DataTable>
    </div>
  </div>
</template>

<script>
import BookService from './services/BookService';
import AuthorService from './services/AuthorService';
import items from './data/menu';
import books from './data/book';

export default {
  name: 'App',
  data() {
    return {
      title: '',
      price: null,
      items: items,
      books: books,
      bookList : [],
      optionsAuthors: [],
      selectedAuthor: null
    }
  },
  bookService: null,
  authorService: null,
  created() {
    this.bookService = new BookService();
    this.authorService = new AuthorService();
  },
  async mounted() {
    console.log('inicio');
    await this.requestGetAuthors();
    await this.requestGetBooks();
    console.log('fim');
  },
  methods: {
    async save() {
      let book = {
        'title': this.title,
        'price': this.price
      };
      if(this.selectedAuthor) {
        book.author = {
          'id': this.selectedAuthor.id
        };
      }
      await this.requestPostBook(book);
    },
    async requestGetBooks() {
      await this.bookService.getBooks()
        .then(response => {
          let data = response.data;
          this.bookList = [];
          data.forEach(book => {
            let bookLocal = {...book};
            bookLocal.author =  bookLocal.author ? bookLocal.author : { name: '-'};
            this.bookList.push({...bookLocal});
          });
        })
        .catch(() => {
          console.log('Ocorreu um erro!');
        });
    },
    async requestGetAuthors() {
      await this.authorService.getAuthors()
        .then(response => {
          let data = response.data;
          this.optionsAuthors= [...data];
        })
        .catch(() => {
          this.optionsAuthors=[];
        })
    },
    async requestPostBook(book = {}) {
      await this.bookService.postBooks(book)
        .then(response => {
          if(response.status === 200) {
            // let data = response.data;
            this.requestGetBooks();
          }
        })
        .catch(() => {
          console.log('error')
        })
    }
  }
}

</script>

<style lang="scss">
  body {
    background-color: #edf0f5;
    margin: 0;
  }
#app {
//   font-family: Avenir, Helvetica, Arial, sans-serif;
//   -webkit-font-smoothing: antialiased;
//   -moz-osx-font-smoothing: grayscale;
//   color: #2c3e50;
  .d-menubar {
    .p-menubar {
      border: none;
      border-radius: 0;
      background: linear-gradient(90deg,#0388e5 0,#07bdf4);
    }
  }
}
</style>
