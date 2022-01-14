<template>
  <Dialog header="Confirmation" v-model:visible="displayConfirmation" :style="{width: '350px'}" :modal="true">
      <div class="confirmation-content">
          <i class="pi pi-exclamation-triangle p-mr-3" style="font-size: 2rem" />
          <span>Are you sure you want to proceed?</span>
      </div>
      <template #footer>
          <Button label="No" icon="pi pi-times" @click="cancelBook" class="p-button-text"/>
          <Button label="Yes" icon="pi pi-check" @click="deleteBook" class="p-button-text" autofocus />
      </template>
  </Dialog>
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
                @change="teste"
              />
            </span>
          </div> 
          <div class="d-button">
            <Button label="Save" @click="save" v-if="isSave"/>
            <Button label="Update" @click="update" v-else/>
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
        <Column :exportable="false">
          <template #body="slotProps">
            <Button icon="pi pi-pencil" class="p-button-rounded p-button-success p-mr-2" @click="editBook(slotProps.data)" />
            <Button icon="pi pi-trash" class="p-button-rounded p-button-warning" @click="confirmDeleteBook(slotProps.data.id)" />
          </template>
        </Column>
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
      book: null,
      id: null,
      title: '',
      price: null,
      items: items,
      books: books,
      bookList : [],
      optionsAuthors: [],
      selectedAuthor:null,
      isSave: true,
      displayConfirmation: false
    }
  },
  bookService: null,
  authorService: null,
  created() {
    this.bookService = new BookService();
    this.authorService = new AuthorService();
  },
  async mounted() {
    await this.requestGetAuthors();
    await this.requestGetBooks();
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
    async update() {
      let book = {
        'title': this.title,
        'price': this.price
      };
      if(this.selectedAuthor) {
        book.author = {
          'id': this.selectedAuthor.id
        };
      }
      await this.requestPutBook(this.id, book);
      this.clearField();
      this.isSave = true;
    },
    async deleteBook(){
      await this.requestDeleteBook(this.id);
      this.displayConfirmation = false;
      this.clearField();
      this.isSave = true;
    },
    cancelBook() {
      this.id= null;
      this.displayConfirmation = false;
      this.clearField();
      this.isSave = true;
    },
    clearField() {
      this.id = null,
      this.title = '',
      this.price = null,
      this.selectedAuthor = null
    },
    editBook(data) {
      this.title = data.title;
      this.price = data.price;
      this.id = data.id;
      let author = {...data.author};
      if(author.name !== '-') {
        this.selectedAuthor = {...author};
      }
      this.isSave = false;
    },
    teste() {
       console.log(this.selectedAuthor);
    },
    confirmDeleteBook(value) {
      this.id = value;
      this.displayConfirmation = true;
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
          data.forEach(author => {
            this.optionsAuthors = [];
            this.optionsAuthors.push({
              id: author.id,
              name: author.name,
              cpf: author.name
            })
          });
          console.log(this.optionsAuthors)
        })
        .catch(() => {
          this.optionsAuthors=[];
        })
    },
    async requestPostBook(book = {}) {
      await this.bookService.postBooks(book)
        .then(() => {
          this.requestGetBooks();
        })
        .catch(() => {
          console.log('error')
        })
    },
    async requestPutBook(bookId, book = {}) {
      await this.bookService.putBooks(bookId, book)
        .then(() => {
          this.requestGetBooks();
        })
        .catch(() => {
          console.log('error')
        })
    },
    async requestDeleteBook(bookId) {
      await this.bookService.deleteBooks(bookId)
        .then(() => {
          this.requestGetBooks();
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
